using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public UI PlayerUI;
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
        Shader.SetGlobalVector("Position", transform.position);
        if (!Alive) MovementEnabled = false;
        animator.SetFloat("Speed", navAgent.velocity.magnitude);
        if (MovementEnabled)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 50))
                {
                    // if(Input.GetAxis("LockMovement") == 0) {
                    {
                        Protagonist.GetPlayerInstance().StopAllAction();
                        navAgent.SetDestination(hit.point);
                    }

                }
            }
        }
    }

    public void TryPickupObject(Item item)
    { 
        navAgent.SetDestination(item.transform.position);
        PlayerUI.GiveItem(item.GetPickedUp());    
        Debug.Log("PickingUpItem");
        Debug.Log(item.gameObject);

        item.gameObject.SetActive(false);            
        return; 
    }
}
