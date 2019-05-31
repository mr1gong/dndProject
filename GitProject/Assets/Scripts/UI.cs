using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    public GameObject Inventory;

    public GameObject QuestSlot0;  public Item Item0;     private UnityEngine.UI.Image QuestSlot0Image;
    public GameObject QuestSlot1;  public Item Item1;     private UnityEngine.UI.Image QuestSlot1Image;
    public GameObject QuestSlot2;  public Item Item2;     private UnityEngine.UI.Image QuestSlot2Image;

    public GameObject WeaponSlot0; public Weapon weapon0; private UnityEngine.UI.Image WeaponSlot0Image;
    public GameObject WeaponSlot1; public Weapon weapon1; private UnityEngine.UI.Image WeaponSlot1Image;
    public GameObject WeaponSlot2; public Weapon weapon2; private UnityEngine.UI.Image WeaponSlot2Image;

    public GameObject Journal;
    public Text MainObjective;
    public Text CurrentObjective;

    private List<GameObject> SlotList = new List<GameObject>();
    private List<GameObject> UiList = new List<GameObject>();

    //List of all UI components indexed by integer
    private Dictionary<int, GameObject> Windows = new Dictionary<int, GameObject>();
    //List of all items derived from a text file
    public static List<Item> Items = new List<Item>();
    //List of all weapons derived from a text file
    public static List<Weapon> Weapons = new List<Weapon>();

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
        QuestSlot0Image = QuestSlot0.GetComponent<UnityEngine.UI.Image>();
        QuestSlot1Image = QuestSlot1.GetComponent<UnityEngine.UI.Image>();
        QuestSlot2Image = QuestSlot2.GetComponent<UnityEngine.UI.Image>();

        WeaponSlot0Image = WeaponSlot0.GetComponent<UnityEngine.UI.Image>();
        WeaponSlot1Image = WeaponSlot1.GetComponent<UnityEngine.UI.Image>();
        WeaponSlot2Image = WeaponSlot2.GetComponent<UnityEngine.UI.Image>();

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
        if (Item0 != null) QuestSlot0Image.sprite = Item0.ItemImage;
        if (Item1 != null) QuestSlot1Image.sprite = Item1.ItemImage;
        if (Item2 != null) QuestSlot2Image.sprite = Item2.ItemImage;




        Debug.Log("Initialisation Successful!");
    }
    
    public void GiveItem(int itemIndex)
    {
        if (Item0 == null)
        {
            Item0 = Items[itemIndex];
            QuestSlot0Image.sprite = Item0.ItemImage;
            return;
        }

        if (Item1 == null)
        {
            Item1 = Items[itemIndex];
            QuestSlot1Image.sprite = Item1.ItemImage;
            return;
        }

        if (Item2 == null)
        {
            Item2 = Items[itemIndex];
            QuestSlot2Image.sprite = Item2.ItemImage;
            return;
        }

        throw new System.Exception("Inventory Overload!");
    }
    public bool GiveItem(Item item)
    {
        if (Item0 == null)
        {
            Item0 = item;
            QuestSlot0Image.sprite = Item0.ItemImage;
            return true;
        }

        if (Item1 == null)
        {
            Item1 = item;
            QuestSlot1Image.sprite = Item1.ItemImage;
            return true;
        }

        if (Item2 == null)
        {
            Item2 = item;
            QuestSlot2Image.sprite = Item2.ItemImage;
            return true;
        }
        return false;
        throw new System.Exception("Inventory Overload!");
    }



    public void RemoveItem(int slotIndex)
    {
        switch (slotIndex)
        {
            case 0:
                Item0 = null;
                break;
            case 1:
                Item1 = null;
                break;
            case 2:
                Item2 = null;
                break;
            default:
                throw new System.Exception("Invalid Input");
        }


    }

    private void ClearSlots()
    {
        bool slot0 = Item0 == null; bool slot1 = Item1 == null; bool slot2 = Item2 == null;

        //If the third item slot (slot2) is null, and all other slots are occupied, the slots are already aligned -> No need to include it in the ifs
        for (int i = 0; i < 2; i++)
        {
            if (slot0 & slot1)
                return;

            if (slot0)
            {
                if (!slot1)
                {
                    Item0 = Item1;
                    Item1 = null;
                }
                else
                {
                    Item0 = Item2;
                    Item2 = null;
                }
            }

            if (slot1)
            {
                Item1 = Item2;
                Item2 = null;
            }
        }
    }
    //by Makovec
    public bool CheckInventorySpace()
    {
        bool slot0 = Item0 == null; bool slot1 = Item1 == null; bool slot2 = Item2 == null;
        return slot0 || slot1 || slot2;
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
