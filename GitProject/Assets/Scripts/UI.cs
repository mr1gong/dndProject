using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    public GameObject Inventory;

    public GameObject QuestSlot0;
    public GameObject QuestSlot1;
    public GameObject QuestSlot2;

    public GameObject WeaponSlot0;
    public GameObject WeaponSlot1;
    public GameObject WeaponSlot2;

    public GameObject Journal;
    public Text MainObjective;
    public Text CurrentObjective;

    private List<GameObject> SlotList = new List<GameObject>();
    private List<GameObject> UiList = new List<GameObject>();
    private Dictionary<int, GameObject> Windows = new Dictionary<int, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Initalise();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
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
        input = null;
    }

    private void Initalise()
    {
        SlotList.Add(QuestSlot0);
        SlotList.Add(QuestSlot1);
        SlotList.Add(QuestSlot2);

        SlotList.Add(WeaponSlot0);
        SlotList.Add(WeaponSlot1);
        SlotList.Add(WeaponSlot2);

        UiList.Add(Journal);
        UiList.Add(Inventory);

        for (int index = 0; index < UiList.Count; index++)
        {
            Windows.Add(index, UiList[index]);
        }
        Debug.Log("Initialisation Successful!");
    }
    
    private void EnableDisableWindow(int index)
    {
        Windows[index].GetComponent<GameObject>();
        //Inverts the enabled-disabled status
        Windows[index].SetActive(!Windows[index].activeSelf);
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            EnableDisableWindow(0);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            EnableDisableWindow(1);
        }
    }
}
