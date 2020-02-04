using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Foe : Combatant
{
    private NavMeshAgent agent;
    public float ViewAngle = 120.0f;
    private SphereCollider col;

    private void Awake()
    {
        col = GetComponent<SphereCollider>();
        agent = GetComponent<NavMeshAgent>();
    }

    protected override void Update()
    {
        base.Update();
    }


    private void OnTriggerStay(Collider other)
    {
        Debug.DrawRay(transform.position, other.transform.position, Color.green,0.1f);
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
               
                if (Physics.Raycast(transform.position,playerDirection.normalized,out hit, col.radius))
                {
                    if(hit.transform.gameObject == other.gameObject)
                    {
                        //Follow player
                        agent.SetDestination(other.transform.position);
                        //Draw raycast
                        Debug.DrawRay(transform.position + transform.up, other.transform.position,Color.red,0.1f);
                        //Check distance
                        if(playerDirection.magnitude <= 4f)
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