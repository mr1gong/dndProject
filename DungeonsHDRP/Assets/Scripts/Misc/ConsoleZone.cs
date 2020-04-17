using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleZone : MonoBehaviour
{
    public bool Enabled = true;
    public string Message;

    protected void OnTriggerEnter(Collider other)
    {
        if (!Enabled)
        {
            return;
        }

        if (other.tag != "Player")
        {
            return;
        }

        Debug.Log("Entered Console Zone");
        Console.GetInstance().StartTransitionIn(Message);
        Enabled = false;
    }
}