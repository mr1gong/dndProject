using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 
 * <summary>
 * V1.1
 * AUTOR: MAKOVEC
 * Basic movement script for player character.
 * </summary>
 **/

public class MovementScript : MonoBehaviour
{
    private Animator animator;
    public float MoveSpeed = 1.0f;
    public float RotSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Vertical") * MoveSpeed*Time.deltaTime;
        var z = Input.GetAxis("Horizontal") * RotSpeed*Time.deltaTime * 100.0f;

        transform.Translate(0, 0, x);
        transform.Rotate(0,z,0);

        if(x > 0)
        {
            animator.SetInteger("MovMode", 1);
        }
        else if( x < 0)
        {
            animator.SetInteger("MovMode", -1);
        }
        else
        {
            animator.SetInteger("MovMode", 0);
        }


    }
}
