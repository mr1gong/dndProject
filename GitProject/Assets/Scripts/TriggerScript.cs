using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerScript : MonoBehaviour
{
    public bool Multiple = false;
    public UnityEvent Trigger;
    private bool triggered = false;


    // Start is called before the first frame update
    

    // Update is called once per frame
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!triggered || Multiple) {
            Trigger.Invoke();
        }
    }
}
