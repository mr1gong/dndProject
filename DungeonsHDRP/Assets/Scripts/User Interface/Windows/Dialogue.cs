using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : UIElement
{
    private static Dialogue _DialogueInstance;
    public Text LastLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Singleton-guarantee method
    public static Dialogue GetInstance()
    {
        if (_DialogueInstance == null)
        {
            _DialogueInstance = FindObjectOfType<Dialogue>();
        }
        return _DialogueInstance;
    }
}
