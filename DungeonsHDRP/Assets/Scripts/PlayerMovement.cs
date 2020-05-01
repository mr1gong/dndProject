using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask Clickable;
    public static bool MovementEnabled = true;
    public static bool Alive = true;

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
        
    }
}
