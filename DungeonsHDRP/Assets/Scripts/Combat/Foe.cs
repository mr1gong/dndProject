using System.Collections;
using System.Collections.Generic;
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
    public float MaxMovementDistance = 4f;

    private void OnDrawGizmos()
    {
       
    }
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        col = GetComponent<SphereCollider>();
        agent = GetComponent<NavMeshAgent>();
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
            //Temporary way to dispose of dead corpses
            Destroy(gameObject);
        }
    }


    protected override void Update()
    {

        if (_animator != null)
        {
            _animator.SetFloat("Speed", agent.velocity.magnitude);
        }
        
        base.Update();
        if(_seePlayerCooldown >= 0) 
        {
            _seePlayerCooldown += Time.deltaTime;
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
        if ((transform.position - _guardianPosition).magnitude <= MaxMovementDistance || !IsGuard)
        {
            Debug.DrawRay(transform.position, other.transform.position, Color.green, 0.1f);

            //Check if the detected object is the Player
            if (other.gameObject.tag == "Player")
            {
                //Get direction and angle
                Vector3 playerDirection = other.transform.position - transform.position;
                float angle = Vector3.Angle(playerDirection, transform.forward);
                //Check if the angle is withing FOV
                if (angle <= ViewAngle / 2)
                {
                    //Check if the player is within visible range
                    RaycastHit hit;

                    if (Physics.Raycast(transform.position, playerDirection.normalized, out hit, col.radius))
                    {
                        if (hit.transform.gameObject == other.gameObject)
                        {
                            _seePlayer = true;
                            //Follow player
                            Target = other.gameObject;
                            agent.SetDestination(other.transform.position);
                            //Draw raycast
                            Debug.DrawRay(transform.position + transform.up, other.transform.position, Color.red, 0.1f);
                            //Check distance
                            if (playerDirection.magnitude <= MaxVisionDistance)
                            {
                                if (coolDownState <= 0)
                                {
                                    Attack(other.gameObject.GetComponent<Protagonist>());
                                    if(_animator != null) 
                                    {
                                        _animator.SetTrigger("Attack");
                                        _animator.ResetTrigger("Attack");
                                    }
                                   
                                }
                                if (agent.remainingDistance <= 0.5 * MaxVisionDistance) 
                                {
                                    agent.isStopped = true;
                                }
                                else 
                                {
                                    agent.isStopped = false;
                                }


                            }
                            else
                            {
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