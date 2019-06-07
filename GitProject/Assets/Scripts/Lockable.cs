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
                OnUnlock.Invoke();
                     lockState = 0;


                if (MessageUIScript.getInstance() != null)
                { MessageUIScript.getInstance().DisplayText("Unlocked!"); }
                     textResult = "Unlocked!";
                     return true;
                }
                
            }
        
        textResult = "Nothing happened.";
        if (MessageUIScript.getInstance() != null)
        { MessageUIScript.getInstance().DisplayText("Nothing happened..."); }
        return false;

    }
    public void Unlock()
    {
        lockState = 0;
    } 
}
