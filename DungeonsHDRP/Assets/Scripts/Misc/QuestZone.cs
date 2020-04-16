using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestZone : MonoBehaviour
{
    private enum ZoneMode
    {
        GiveMainObjective,
        GiveCurrentObjective,
        RemoveMainObjective,
        RemoveCurrentObjective
    }

    public bool Enabled = true;
    public string Quest = "Hello, knight!";

    [SerializeField]
    private ZoneMode ZoneFunction;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (!Enabled)
        {
            return;
        }

        if (other.tag != "Player")
        {
            return;
        }

        switch (ZoneFunction)
        {
            case ZoneMode.GiveMainObjective:
                Journal.GetInstance().ChangeMainObjective(Quest);
                return;
            case ZoneMode.GiveCurrentObjective:
                Journal.GetInstance().ChangeSecondaryObjective(Quest);
                return;
            case ZoneMode.RemoveMainObjective:
                Journal.GetInstance().ClearText(Journal.GetInstance().MainObjective);
                return;
            case ZoneMode.RemoveCurrentObjective:
                Journal.GetInstance().ClearText(Journal.GetInstance().CurrentObjective);
                return;
            default:
                throw new System.Exception("Invalid Input!");
        }
    }
}