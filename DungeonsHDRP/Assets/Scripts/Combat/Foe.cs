using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Foe : Combatant
{
    private NavMeshAgent agent;
    private SphereCollider col;
    public bool IsGuard = false;
    private Vector3 _guardianPosition;
    private bool _seePlayer = false;
    public float _seePlayerCooldown = 2f;
    public float MaxDistance = 4f;

    private void Awake()
    {
        col = GetComponent<SphereCollider>();
        agent = GetComponent<NavMeshAgent>();
    }

    protected override void Start()
    {
        _guardianPosition = gameObject.transform.position;
        base.Start();
    }
    protected override void Update()
    {
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

        if ((transform.position - _guardianPosition).magnitude > MaxDistance && IsGuard)
        {
            agent.SetDestination(_guardianPosition);
        }
        }


    private void OnTriggerStay(Collider other)
    {
        if ((transform.position - _guardianPosition).magnitude <= MaxDistance )
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
                            Target = other.gameObject.GetComponent<Interactible>();
                            agent.SetDestination(other.transform.position);
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