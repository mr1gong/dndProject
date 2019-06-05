/**
 * Author: Marek Makovec
 **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactible : MonoBehaviour
{
    //Jindrich Code Intrusion Alert
    public Texture2D IdleMode;
    public Texture2D Interaction;
    private CursorMode CursorMode = CursorMode.Auto;
    private Vector2 CursorOffset = new Vector2(0, 0);

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

    private void OnMouseEnter()
    {
        //Cursor.SetCursor(Interaction, CursorOffset, CursorMode);
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

        //Reserved for future versions.
        //Like in Intel processors?
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
