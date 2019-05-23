using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    //DO TIME OFFSET
    public List<Vector3> DoorPositions;
    private Vector3 target;       
    public float Speed = 1.0f;
    public int index = 0;
    private bool beingHandled = false;
    private float timer;

    // Use this for initialization
    void Start()
    {



        
    }

    // Update is called once per frame
    void Update()
    {

        try
        {
            target = DoorPositions[index];
            float step = Speed * Time.deltaTime;

            if (Quaternion.Angle(transform.rotation, Quaternion.Euler(target)) == 0)
            {

            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(target), step);
            }
            //For some reason Unity doesn't know Exceptions... truly exceptional programming skills
        } catch(System.Exception e) { }
        
    }

   
}
