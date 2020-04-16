using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.IO;

public class Protagonist : Combatant
{
    private bool init = false;
    private static Protagonist playerInstance;
    private NavMeshAgent _agent;
    private SphereCollider _col;


    //JINDRICH CODE INTRUSION
    void Awake()
    {
        LoadCharacterStats();
    }

    protected override void Start()
    {
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
        this.Target = interactible;
    }
    public void StopAllAction() 
    {
        this.Target = null;
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
    }
    public override void ReceiveDamange(int damageSustained)
    {
        base.ReceiveDamange(damageSustained);
        VitalsDisplay.GetInstance().SetHitPoints(this.HitPoints*100/this.HitPoitMaximum);
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
                Vector3 playerDirection = other.transform.position - transform.position;
                float angle = Vector3.Angle(playerDirection, transform.forward);

                //Check if the angle is withing FOV
                if (angle <= ViewAngle / 2)
                {
                    //Check if the player is within visible range
                    RaycastHit hit;

                    if (Physics.Raycast(transform.position, playerDirection.normalized, out hit, _col.radius))
                    {
                        if (hit.transform.gameObject == other.gameObject)
                        {
                            //Follow player
                            _agent.SetDestination(other.transform.position);
                            //Draw raycast
                            Debug.DrawRay(transform.position + transform.up, other.transform.position, Color.red, 0.1f);
                            //Check distance
                            if (playerDirection.magnitude <= 4f)
                            {
                                if (coolDownState <= 0)
                                {
                                    Attack(other.gameObject.GetComponent<Protagonist>());
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

        ArmourClass = 10; HitPoitMaximum = 12 + GetModifier(Ability.Constitution);
        HitPoints = HitPoitMaximum;
    }
}