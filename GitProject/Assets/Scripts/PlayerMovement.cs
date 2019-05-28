using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    public LayerMask Clickable;
    private NavMeshAgent navAgent;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 50 , Clickable))
            {
                navAgent.SetDestination(hit.point);
            }
        }
        animator.SetFloat("Speed", Mathf.Abs(navAgent.velocity.x));
    }
}
