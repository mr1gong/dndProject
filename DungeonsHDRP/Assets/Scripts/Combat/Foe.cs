using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Foe : Combatant
{
    private NavMeshAgent agent;
    private SphereCollider col;
    private Animator _animator;
    public bool IsGuard = false;
    private Vector3 _guardianPosition;
    private bool _seePlayer = false;
    public float _seePlayerCooldown = 2f;
    public float MaxVisionDistance = 4f;
    public float MaxAttackDistance = 1f;
    public float MaxMovementDistance = 4f;
    public float LosePlayerTime = 4f;
    private bool dead = false;
    public bool followPlayer = false;

    private void OnDrawGizmos()
    {
        
        Gizmos.DrawWireSphere(transform.position, MaxVisionDistance);
        Vector3 playerDirection = Protagonist.GetPlayerInstance().transform.position+ new Vector3(0,1,0);
        Gizmos.DrawLine(transform.position, playerDirection);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, MaxAttackDistance);
    }
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        col = GetComponent<SphereCollider>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void NotifyOfPlayer()
    {
        Target = Protagonist.GetPlayerInstance().gameObject;
        FollowPlayer();
    }
    protected override void Start()
    {
        _guardianPosition = gameObject.transform.position;
        base.Start();
    }
    public override void ReceiveDamange(int damageSustained)
    {
        base.ReceiveDamange(damageSustained);
        
        if(this.HitPoints <= 0) 
        {
           
            if(_animator == null) 
            {
                Destroy(gameObject);
            }
            else 
            {
                if (!dead)
                {
                    GetComponent<Rigidbody>().isKinematic = false;
                    GetComponent<Rigidbody>().useGravity = false;
                    dead = true;
                    _animator.SetTrigger("Death");
                    GetComponents<Collider>().ToList().ForEach(x => { x.enabled = false; });
                    this.enabled = false;
                    agent.enabled = false;
                    
                }
            }
           

        }
    }
    public void FollowPlayer() 
    {
        agent.SetDestination(Protagonist.GetPlayerInstance().transform.position);
    }
    public void ProcessAttack() 
    {


        if (!dead)
        {
            Collider other;
            other = Physics.OverlapSphere(transform.position, MaxVisionDistance).Where(x=>x.tag == "Player").Select(x=>x).FirstOrDefault();
            if (other != null)
            {
                if ((transform.position - _guardianPosition).magnitude <= MaxMovementDistance || !IsGuard)
                {
                    Debug.DrawRay(transform.position, other.transform.position, Color.green, 0.1f);

                    //Check if the detected object is the Player
                    if (other.gameObject.tag == "Player")
                    {
                        Debug.Log("Step1");
                        //Get direction and angle
                        Vector3 playerDirection = other.transform.position - transform.position+ new Vector3(0, 1, 0);
                        float angle = Vector3.Angle(playerDirection.normalized, transform.forward);
                        //Check if the angle is withing FOV
                        //Debug.Log(angle + ";" + ViewAngle / 2);
                        if (angle <= ViewAngle / 2)
                        {

                            Debug.Log("Step2");
                            //Check if the player is within visible range
                            RaycastHit hit;
                            
                            if (Physics.Raycast(transform.position, playerDirection.normalized, out hit, MaxVisionDistance))
                            {
                                Debug.Log("Step3");
                                Debug.Log(hit.transform.gameObject.name);
                                if (hit.transform.gameObject == other.gameObject)
                                {
                                    Debug.Log("Step4");

                                    _seePlayer = true;
                                    _seePlayerCooldown = LosePlayerTime;
                                    //Follow player
                                    Target = other.gameObject;
                                    agent.SetDestination(other.transform.position);
                                    //Draw raycast
                                    Debug.DrawRay(transform.position + transform.up, other.transform.position, Color.red, 0.1f);
                                    //Check distance
                                    if (playerDirection.magnitude <= MaxAttackDistance)
                                    {
                                        transform.LookAt(Target.transform);
                                        agent.isStopped = true;
                                        if (coolDownState <= 0)
                                        {

                                            Attack(other.gameObject.GetComponent<Protagonist>());
                                            if (_animator != null)
                                            {
                                                _animator.Play("Armature|Attack");
                                            }

                                        }

                                    }
                                    else
                                    {
                                        agent.isStopped = false;
                                    }
                                }
                                else
                                {
                                    _seePlayer = false;
                                }
                            }
                            else
                            {
                                _seePlayer = false;
                            }
                        }
                        else
                        {

                        }
                    }
                }
            }
        }
    }

    protected override void Update()
    {

        if (_animator != null)
        {
            _animator.SetFloat("Speed", agent.velocity.magnitude);
        }
        
        if(followPlayer) 
        {
            FollowPlayer();
        }
        base.Update();
        ProcessAttack();
        if (_seePlayerCooldown >= 0) 
        {
            _seePlayerCooldown -= Time.deltaTime;
        }
        else 
        {
            Target = null;
        }
        if( Target == null && IsGuard)
        {
            agent.SetDestination(_guardianPosition);
        }

        if ((transform.position - _guardianPosition).magnitude > MaxMovementDistance && IsGuard)
        {
            agent.SetDestination(_guardianPosition);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        
    }
}