using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageUIScript : MonoBehaviour
{
    //Trochu Fucked up singleton
    private MessageUIScript() { instance = this; }
    private static MessageUIScript instance;
    private string text = "";
    private float alpha = 0;

    private void Update()
    {
        //constantly decrease alpha level;
        if (alpha > 0) { alpha -= 0.001f; }
        if(alpha < 0) { alpha = 0; }
    }

    public static MessageUIScript getInstance()
    {
        if(instance == null)
        {
            instance = new MessageUIScript();
        }
        return instance;
    }

    public void DisplayText(string message)
    {
        alpha = 1;
        text = message;
    }

    private void OnGUI()
    {
        //Display Text
        GUI.skin.label.fontSize = 20;
        GUI.color = GUI.color = new Color(1, 1, 1, alpha);
        GUI.Label(new Rect(10, 0, 500, 50), text);
         
    }
}
