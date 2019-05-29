using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactible : MonoBehaviour
{

    public string ExamineText = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public abstract bool GetItemUsedOn(Item item, out string textResult);
    public string GetExamined()
    {
        return ExamineText;
    }
    
}
