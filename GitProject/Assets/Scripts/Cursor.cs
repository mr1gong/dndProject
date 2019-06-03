using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public Texture2D IdleMode;
    public Texture2D Interaction;
    public CursorMode CursorMode = CursorMode.Auto;
    // Start is called before the first frame update
    void Start()
    {

    }
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
