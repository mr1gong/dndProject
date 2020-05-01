using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorScript : Lockable
{

    //DO TIME OFFSET
    public List<Vector3> DoorPositions;
    public List<DoorScript> linkedDoors;
    private Vector3 target;
    public float Speed = 1.0f;
    public int index = 0;
    private bool beingHandled = false;

    // Update is called once per frame

    public override void Unlock()
    {

        base.Unlock();
        if (this.lockState != 0)
        {
            foreach (var v in linkedDoors)
            {
                v.Unlock();
            }
        }
    }

    void Update()
    {
        UIUpdate();

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
            else
        {
            
        }

        foreach (DoorScript door in linkedDoors)
        {
            door.lockState = lockState;

        }
    }
    
    public void SetDoorState(int i)
    {
        if (lockState == 0)
        {
            index = i;
            foreach (DoorScript door in linkedDoors)
            {

                door.index = index;
            }
        }
        else
        {
            Console.GetInstance().StartTransitionIn("Locked!");
        }
    }
    public void IncrementDoorState()
    {
        if (lockState == 0)
        {
            if (index + 1 >= DoorPositions.Count) { index = 0; }
        else { index++; }
        foreach (DoorScript door in linkedDoors)
        {
            
            door.index = index;
        }

        }
        else
        {
            Console.GetInstance().StartTransitionIn("Locked!");
        }
    }
}

   

