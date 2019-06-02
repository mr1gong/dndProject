/**
 * Author: Marek Makovec
 **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactible : MonoBehaviour
{
    public Shader alwaysOnTop;
    protected float Timer;
    public Canvas interactibleUISet;
    public string ExamineText = "";
    // Start is called before the first frame update
    void Start()
    {
        Canvas.GetDefaultCanvasMaterial().shader = alwaysOnTop;
        Timer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        interactibleUISet.transform.LookAt(Camera.main.transform);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
           
        if (Physics.Raycast(ray, out hit))
        {
                       
            if (hit.collider.gameObject == this.gameObject)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    Timer = 0;
                    
                    interactibleUISet.enabled = true;
                }

                
            }
            else
            {

                Timer += Time.deltaTime;
                if (Timer > 2000)
                {
                    interactibleUISet.enabled = false;
                }
            }
        }

        //Reserved for future versions
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
