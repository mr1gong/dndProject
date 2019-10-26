using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerScript : MonoBehaviour
{
    public bool Multiple = false;
    public UnityEvent Trigger;
    public bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
  
        if ((!triggered) || Multiple)
        {
            Trigger.Invoke();
            triggered = true;
        }
    }
}
