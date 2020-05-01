using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimedEvent : MonoBehaviour
{
    public float secondsTicked = 0;
    public float secondsTarget = 5;

    public UnityEvent OnTimerFinish;

    public bool Running = false;
    public bool Silent = true;
    public string Message = "Time remaining";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Running)
        {
            if (secondsTicked < secondsTarget)
                secondsTicked += Time.deltaTime;

            if (secondsTicked >= secondsTarget)
            {
                OnTimerFinish.Invoke();
                Running = false;
            }

        }
        if (!Silent && Running)
        {
            TimeSpan time = TimeSpan.FromSeconds(secondsTarget - secondsTicked);


            string str = Message + ": " + time.ToString(@"mm\:ss\:ff");

            MessageUIScript.getInstance().DisplayText(str);
        }
    }

    public void TimerStart() 
    {
        Running = true;
    }

    public void TimerStop() 
    {
        Running = false;
    }
}
