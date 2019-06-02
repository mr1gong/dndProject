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
    protected float timer;
    public Canvas interactibleUISet;
    public string ExamineText = "";
    // Start is called before the first frame update
    void Start()
    {
        Canvas.GetDefaultCanvasMaterial().shader = alwaysOnTop;
        timer = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        UIUpdate();

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

    protected void UIUpdate()
    {
        interactibleUISet.transform.LookAt(Camera.main.transform);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider.gameObject == this.gameObject)
            {
                Debug.Log("EQUALS");
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("CLICK");

                    timer = 0;


                }


            }
            else
            {

                timer += Time.deltaTime;

            }
            
        }

        //Reserved for future versions
        else { }

        if (timer > 2)
        {
            interactibleUISet.enabled = false;
        }
        else
        {
            interactibleUISet.enabled = true;

        }
    }

}
