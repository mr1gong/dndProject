using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lockable : Interactible
{ 
    public Item[] Keys;
    public int lockState = 0;
    public UnityEvent OnUnlock;
    
    public override bool GetItemUsedOn(Item item, out string textResult)
    {
        foreach (Item key in Keys)
        {

            if (key == item)
            {
                Debug.Log(key);
                Debug.Log(item);
                OnUnlock.Invoke();
                lockState = 0;

                Console.GetInstance().StartTransitionIn("Unlocked!");
                textResult = "Unlocked!";
                return true;
             }  
        }
        
        textResult = "Nothing happened.";
        Console.GetInstance().StartTransitionIn("Nothing happened.");
        return false;
    }

    public void Unlock()
    {
        lockState = 0;
    } 
}
