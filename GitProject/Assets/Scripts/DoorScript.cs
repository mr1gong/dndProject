using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Lockable
{

    //DO TIME OFFSET
    public List<Vector3> DoorPositions;
    private Vector3 target;
    public float Speed = 1.0f;
    public int index = 0;
    private bool beingHandled = false;
    private float timer;

  
    // Update is called once per frame
    void Update()
    {
        interactibleUISet.transform.LookAt(Camera.main.transform);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Timer = 0;

                    interactibleUISet.enabled = true;
                }

                else
                {

                    Timer += Time.deltaTime;
                    if (Timer > 2)
                    {
                        interactibleUISet.enabled = false;
                    }
                }
            }

            if (lockState == 0)
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
                }
                catch (System.Exception e) { }
            }
        }
    }
    public void SetDoorState(int i)
    {
        index = i;
    }
    public void IncrementDoorState()
    {
        if (index + 1 >= DoorPositions.Count) { index = 0; }
        else { index++; }
    }
}

   

