using UnityEngine;
using UnityEngine.UI;

public class StartZone : QuestZone
{   private enum ZoneMode
    {
        GiveBoth,
        RemoveBoth
    }

    public string SecondaryQuest = "And hello there, fair lady!";

    [SerializeField]
    private ZoneMode ZoneFunction;

    protected override void OnTriggerEnter(Collider other)
    {
        Debug.Log($"ENTERED START ZONE\n{Journal.GetInstance().CurrentObjective.text}");
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
            case ZoneMode.GiveBoth:
                Debug.Log($"ENTERED START ZONE\n{Journal.GetInstance().CurrentObjective.text}");
                Journal.GetInstance().ChangeMainObjective(Quest);
                Journal.GetInstance().ChangeSecondaryObjective(SecondaryQuest);
                return;
            case ZoneMode.RemoveBoth:
                Debug.Log($"ENTERED START ZONE\n{Journal.GetInstance().CurrentObjective.text}");
                Journal.GetInstance().ClearText(Journal.GetInstance().MainObjective);
                Journal.GetInstance().ClearText(Journal.GetInstance().CurrentObjective);
                return;
            default:
                throw new System.Exception("Invalid Input!");
        }
    }
}
