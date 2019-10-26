using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public Texture2D IdleMode;
    public Texture2D Interaction;
    private CursorMode CursorMode = CursorMode.Auto;
    private Vector2 CursorOffset = new Vector2(0, 0);
    // Start is called before the first frame update
    void Start()
    {

    }

    /*public void UpdateCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast (ray, out hit, 10000))
        {
            if (hit.transform.tag == "interactible")
            {
                Cursor.SetCursor(Interaction, CursorOffset, CursorMode);
            }
        }
    }*/

    /**
     * 
     * Syntax for cursor modification is as follows:
     * 
     * Cursor.SetCursor(cursorTexture, hospot (Vector from the interactible script), CursorMode (Taken from the class header));
     * 
     * FOR THIS TO WORK THE INTERACTIBLE OBJECT MUST HAVE A RIGIDBODY (as well as a tag for you to differentaite between interactibles
     * and non-interactibles
     * **/

    // Update is called once per frame
    void Update()
    {
        
    }
}
