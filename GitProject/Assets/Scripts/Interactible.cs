using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    private float Timer;
    public Canvas interactibleUISet;
    public string ExamineText = "";
    // Start is called before the first frame update
    void Start()
    {
        Timer = 10;
    }

    // Update is called once per frame
    void Update()
    {

        
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
                }
                else { }
            
        
    }
    
    public virtual bool GetItemUsedOn(Item item, out string textResult)
    {
        textResult = "Nothing Happened.";
        return false;
    }
    public string GetExamined()
    {
        return ExamineText;
    }
    
}
