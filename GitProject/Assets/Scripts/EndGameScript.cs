using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{

    public bool Endgame = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGUI()
    {
        if (Endgame)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, Screen.width / 2, Screen.height / 2), "The End");
        }
    }
    public void End()
    {
        Endgame = true;
    }
}
