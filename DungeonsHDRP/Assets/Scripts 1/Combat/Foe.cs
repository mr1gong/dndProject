using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Foe : Combatant
{
    private NavMeshAgent agent;
    public float ViewAngle = 45.0f;
    //DO NOT CHANGE DURING RUNTIME
    public float ViewDistance = 10f;

    protected void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
    }
    protected override void Update()
    {
        base.Update();
        Target = LookForTarget(ViewAngle,ViewDistance,10);
        if(Target == null)
        Target = LookForTarget(360, ViewDistance/4, 30);
        if(Target!=null)
        {
            Attack(Target);
            agent.SetDestination(Target.transform.position);
        }
    }

    protected Character LookForTarget(float angle, float distance, int dispersion = 10)
    {
        Target = null;
        Character c = null;
        Vector3 startPos  = transform.position; // umm, start position !
        Vector3 targetPos = Vector3.forward; // variable for calculated end position

        var startAngle = (int)(-angle * 0.5); // half the angle to the Left of the forward
        var finishAngle = (int)(angle * 0.5); // half the angle to the Right of the forward

        // the gap between each ray (increment)
        var inc = (int)(angle / dispersion);

        RaycastHit hit;

        // step through and find each target point
        for (int i = startAngle; i < finishAngle; i += inc ) // Angle from forward
     {
            targetPos = (Quaternion.Euler(0, i, 0) * transform.forward).normalized * distance;

            // linecast between points
            if (Physics.Raycast(startPos, targetPos, out hit, distance))
            {
                Debug.DrawLine(startPos,hit.transform.position);
                
                    c = hit.collider.gameObject.GetComponent<Character>();
                    Debug.Log(hit.collider.gameObject.name);
            }
             
            // to show ray just for testing
            Debug.DrawLine(startPos, targetPos, Color.green);
        }
        return c;
    }
}
