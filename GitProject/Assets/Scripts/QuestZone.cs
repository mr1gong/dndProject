using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestZone : MonoBehaviour
{
    public bool enter = true;
    //0: Give Main Objective; 1: Give Current Objective; 2: Remove Main Objective; 3: Remove Current Objective
    public int ZoneFunction;
    public Text MainObjective;
    public Text CurrentObjective;
    public string Quest = "Hello, knight!";

    void Start()
    {
        MainObjective.GetComponent<Text>();
        CurrentObjective.GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enter)
        {
            Debug.Log("entered");
        }

        switch (ZoneFunction)
        {
            case 0:
                ChangeMainObjective(Quest);
                return;
            case 1:
                ChangeSecondaryObjective(Quest);
                return;
            case 2:
                ClearText(MainObjective);
                return;
            case 3:
                ClearText(CurrentObjective);
                return;
            default:
                throw new System.Exception("Invalid Input!");
        }
    }

    public void ChangeMainObjective(string input)
    {
        ClearText(MainObjective);
        MainObjective.text = input;
    }

    public void ChangeSecondaryObjective(string input)
    {
        ClearText(CurrentObjective);
        CurrentObjective.text = input;
    }

    public void ClearText(Text input)
    {
        Debug.Log(Quest);
        input = null;
    }
}