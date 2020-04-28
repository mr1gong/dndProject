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
    private SphereCollider _col;
    private Interactible _target;
    private bool _ItemSelectionMode = false;
    private bool _SelectionMode = false;


    //JINDRICH CODE INTRUSION
    void Awake()
    {
        LoadCharacterStats();
    }

    protected override void Start()
    {
        Anim = GetComponent<Animator>(); 
        _agent = GetComponent<NavMeshAgent>();
        _col = GetComponent<SphereCollider>();
        playerInstance = this;
        Canvas.GetDefaultCanvasMaterial().shader = alwaysOnTop;
        timer = 10000;

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
        this.Target = interactible.gameObject;
    }

    public void SetTarget(Item item) 
    {
        this.Target = item.gameObject;
        this._ItemSelectionMode = true;
    }
    public void StopAllAction() 
    {
        Debug.Log("Stopped All Action");
        this.Target = null;
        this._SelectionMode =false;
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
        base.Update();
        //VitalsDisplay.HitPoints = this.HitPoints;
        //if (!init) { VitalsDisplay.GetInstance().SetDefaultHP(this.HitPoints,true); init = true; }
        if (_SelectionMode)
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
                        case "Item": { _SelectionMode = false; Debug.Log("Selected Item"); break; }
                        case "Enemy": { SetTarget(hitout.GetComponent<Interactible>()); _SelectionMode = false; Debug.Log("Selected Enemy"); break; }
                    }
                    _SelectionMode = false;
                }
            }
        }
        else
        {

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
        Debug.DrawRay(transform.position, other.transform.position, Color.green, 0.1f);
        //Check if the detected object is the Player
        if (Target != null)
        {
            if (other.gameObject == Target.gameObject)
            {
                //Get direction and angle
                Vector3 targetDirection = other.transform.position - transform.position;
                float angle = Vector3.Angle(targetDirection, transform.forward);

                //Check if the angle is withing FOV
                if (angle <= ViewAngle / 2)
                {
                    //Check if the target is within visible range
                    RaycastHit hit;

                    if (Physics.Raycast(transform.position, targetDirection.normalized, out hit, _col.radius))
                    {
                        if (hit.transform.gameObject == other.gameObject)
                        {
                            //Follow player
                            _agent.SetDestination(other.transform.position);
                            //Draw raycast
                            Debug.DrawRay(transform.position + transform.up, other.transform.position, Color.red, 0.1f);
                            //Check distance
                            if (targetDirection.magnitude <= 4f)
                            {
                                if (_ItemSelectionMode)
                                {
                                    //Picks up item and puts it into inventory
                                    GetComponent<InventoryComponent>().Inventory.Add(other.GetComponent<Item>().GetPickedUp());
                                }
                                else
                                {
                                    _agent.isStopped = true;
                                    if (coolDownState <= 0)
                                    {
                                        //It already does deal damage along with returning the attack value
                                        int attackRoll = Attack(other.gameObject.GetComponent<Interactible>());
                                        Anim.Play("Armature|Attack");
                                        RollDisplay.GetInstance().ShowRoll(attackRoll);

                                    }
                                    else
                                    {
                                        _agent.isStopped = false;
                                    }
                                }
                                
                            }
                        }
                    }
                }
            }
        }
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