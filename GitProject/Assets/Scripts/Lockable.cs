using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockable : Interactible
{
    
    public Item[] Keys;
    public int lockState = 0;

    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public override bool GetItemUsedOn(Item item, out string textResult)
    {
        
            foreach (Item key in Keys)
            {

                if (key == item)
                {
                     lockState = 0;
                     textResult = "Unlocked!";
                     return true;
                }
                
            }
        
        textResult = "Nothing happened.";
        return false;

    }

}
