using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.IO;

public class Protagonist : Combatant
{
    private bool init = false;
    private static Protagonist playerInstance;
    public Animator Anim { get; private set; }
    private NavMeshAgent _agent;
    private Interactible _target;
    private bool _ItemSelectionMode = false;
    private bool _SelectionMode = false;
    public float PlayerMaxViewDistance = 5f;
    private bool dead = false;
    public float MaxReach = 2f;


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, MaxReach);
    }

    //JINDRICH CODE INTRUSION
    void Awake()
    {
        LoadCharacterStats();
    }

    protected override void Start()
    {
        Anim = GetComponent<Animator>(); 
        _agent = GetComponent<NavMeshAgent>();
        playerInstance = this;
        Canvas.GetDefaultCanvasMaterial().shader = alwaysOnTop;
        timer = 10000;
        Time.timeScale = 1;

        GameObject MiniUiPrefabObject = Instantiate(MiniUIPrefab, gameObject.transform);
        MiniUI = MiniUiPrefabObject.GetComponent<MiniUIController>();

        if (MiniUI != null && UIActionButtons != null)
        {
            MiniUI.LoadUIActions(UIActionButtons);
        }

        _IsInvincible = false;
        MiniUI.gameObject.SetActive(false);

        VitalsDisplay.GetInstance().SetSpeed(Speed);
        VitalsDisplay.GetInstance().SetArmourClass(ArmourClass);
    }

    public void SetTarget(Interactible interactible) 
    {
        StopAllAction();
        this.Target = interactible.gameObject;
    }

    public void SetTarget(Item item) 
    {
        StopAllAction();
        Debug.Log("Target Item");
        this.Target = item.gameObject;
        this._ItemSelectionMode = true;
    }
    public void StopAllAction() 
    {
        Debug.Log("Stopped All Action");
        this.Target = null;
        this._SelectionMode =false;
        _agent.isStopped = true;
        _agent.isStopped = false;
        _agent.SetDestination(transform.position);
    }
    public void MakeInvincible(bool input)
    {
        _IsInvincible = input;
    }

    public static Protagonist GetPlayerInstance() 
    {
    if(playerInstance == null) 
        {
            playerInstance = GameObject.FindObjectOfType<Protagonist>();
        }
        return playerInstance;
    }

    public void MakeInvincible()
    {
        _IsInvincible = true;
    }

    public void PickUpItem(Item item) 
    {
        
    }

    protected override void InitiateDeathSequence()
    {
        UIController.GetInstance().SwitchWindow(UIController.WindowNameResource.DeathSequence);
        //_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        PlayerMovement.MovementEnabled = false;
    }

    protected override void Update()
    {
        Shader.SetGlobalVector("Position", transform.position);
        base.Update();
        //VitalsDisplay.HitPoints = this.HitPoints;
        //if (!init) { VitalsDisplay.GetInstance().SetDefaultHP(this.HitPoints,true); init = true; }
        if (_SelectionMode)
        {
            HandleItemSelection();
        }
        else
        {
            if(Target != null) 
            {
                if(_ItemSelectionMode) 
                {
                    
                    TryToPickupItem();
                }
                else 
                {
                    HandleAttack();
                }
              

            }
           
        }

            Anim.SetFloat("Speed", _agent.velocity.magnitude);
           
           
        if (Input.GetMouseButtonDown(1))     
        {
            Protagonist.GetPlayerInstance().StopAllAction();
            if (Target == null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, 50))
                    {
                        // if(Input.GetAxis("LockMovement") == 0) {
                        {
                            
                            _agent.SetDestination(hit.point);
                            Debug.Log(hit.collider.gameObject.name);
                        }

                    }
            
            }

            
        }

    }
    private void HandleAttack() 
    {
        if(Target.GetComponent<Interactible>() != null) 
        { if (Target.GetComponent<Interactible>().HitPoints <= 0) 
            {
                StopAllAction();
            }
        
        }
        
        //Debug.Log("ATTACKING" + Target);
        if (Target != null)
        {
                

         
                //Get direction and angle
                Vector3 targetDirection = Target.transform.position - transform.position ;
                float angle = Vector3.Angle(targetDirection, transform.forward);
                //Debug.Log(targetDirection.magnitude);
                //Check if the angle is withing FOV
                if (angle <= ViewAngle / 2)
                {
                //Debug.Log("Anhgle" + angle + ";" + ViewAngle/2);
                    //Check if the target is within visible range
                    RaycastHit hit;

                    if (Physics.Raycast(transform.position, targetDirection.normalized, out hit, PlayerMaxViewDistance))
                    {
                        if (hit.transform.gameObject == Target.gameObject)
                        {
                            //Follow player
                            _agent.SetDestination(Target.transform.position);
                            //Draw raycast
                            Debug.DrawRay(transform.position + transform.up, Target.transform.position, Color.red, 0.1f);
                        //Check distance

                        Debug.Log(targetDirection.magnitude+""+ MaxReach * Target.transform.localScale.magnitude);
                        if (targetDirection.magnitude <= MaxReach * Target.transform.localScale.magnitude/2 && Target != null)
                           
                        {
                            
                            _agent.isStopped = true;


                            if (coolDownState <= 0)
                                    
                            {
                                        //It already does deal damage along with returning the attack value
                                        int attackRoll = Attack(Target.gameObject.GetComponent<Interactible>());
                                        Anim.Play("Armature|Attack");
                                        RollDisplay.GetInstance().ShowRoll(attackRoll);

                                    
                            }
                                   
                            else
                                   
                            {

                                   
                            }
                             

                        
                       
                        }
                        else 
                        {
                            _agent.isStopped = false;
                        }
                    }
                }
            }
        }
        else
        {

        }
    }

    private void HandleItemSelection() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, float.PositiveInfinity, LayerMask.GetMask("Clickable")))
            {
                Debug.Log("HIT" + hit.collider.gameObject.tag);
                GameObject hitout = hit.collider.gameObject;
                switch (hitout.tag)
                {
                    case "Item": { _SelectionMode = false; Debug.Log("Selected Item"); _SelectionMode = false; break; }
                    case "Enemy": { SetTarget(hitout.GetComponent<Interactible>()); _SelectionMode = false; Debug.Log("Selected Enemy"); _SelectionMode = false; break; }
                }
                
            }
        }
    }


    private void TryToPickupItem()
    {
        _agent.SetDestination(Target.transform.position);
        var targetDirection = Target.transform.position - transform.position;

        if (targetDirection.magnitude <= 3f && Target != null)
        {
            //_agent.isStopped = true;
            if (_ItemSelectionMode)
            {
                //Picks up item and puts it into inventory
                GetComponent<InventoryComponent>().Inventory.Add(Target.GetComponent<Item>().GetPickedUp());
                _ItemSelectionMode = false;
                _target = null;
            }

        }
    }
    public override void ReceiveDamange(int damageSustained)
    {
        base.ReceiveDamange(damageSustained);
        VitalsDisplay.GetInstance().SetHitPoints(this.HitPoints/this.HitPoitMaximum*100);
    }

    public void SetTargetSelectMode(bool mode) 
    {
        _SelectionMode = mode;
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void LoadCharacterStats()
    {
        string rawData = File.ReadAllText("CharacterSave.txt").Trim();
        string[] splitData = rawData.Split(',');
        int[] parsedData = new int[splitData.Length];

        for (int index = 0; index < splitData.Length; index++)
        {
            parsedData[index] = int.Parse(splitData[index]);
        }

        Strength = parsedData[0]; Dexterity = parsedData[1]; Constitution = parsedData[2];
        Intelligence = parsedData[3]; Wisdom = parsedData[4]; Charisma = parsedData[5];

        ArmourClass = 10 + GetModifier(Ability.Dexterity);
        HitPoitMaximum = 12 + GetModifier(Ability.Constitution);
        HitPoints = HitPoitMaximum;
    }
}