using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public UI PlayerUI;
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
        animator.SetFloat("Speed", navAgent.velocity.magnitude);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 50))
            {
                if(Input.GetAxis("LockMovement") == 0) {
                    navAgent.velocity = new Vector3(0, 0, 0);
                    navAgent.SetDestination(hit.point);
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
