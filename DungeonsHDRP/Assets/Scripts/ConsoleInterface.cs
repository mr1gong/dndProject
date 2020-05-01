using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleInterface : MonoBehaviour
{
     public void ShowMessage(string message) 
        {
        Console.GetInstance().StartTransitionIn(message);
        }
}
