//UNFINISHED!

#region Implementations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class Inventory : MonoBehaviour
{
    #region Fields
    public GameObject Window;
    public Sprite DefaultItemImage;

    public GameObject WeaponSlot0;
    public GameObject WeaponSlot1;
    public GameObject WeaponSlot2;

    public GameObject QuestItemSlot0;
    public GameObject QuestItemSlot1;
    public GameObject QuestItemSlot2;

    public Item Weapon0;
    public Item Weapon1;
    public Item Weapon2;

    public Item QuestItem0;
    public Item QuestItem1;
    public Item QuestItem2;

    public Image WeaponSlotImage0;
    public Image WeaponSlotImage1;
    public Image WeaponSlotImage2;

    public Image QuestSlotImage0;
    public Image QuestSlotImage1;
    public Image QuestSlotImage2;
    public static List<Item> AvailableItems;
    public static List<Weapon> AvailableWeapons;

    private List<GameObject> SlotList;
    private Item selectedItemForUse;
    private bool isActive;
    #endregion

    #region Window-Unspecific Bloc
    // Start is called before the first frame update
    void Start()
    {
        Window.GetComponent<GameObject>();
        SlotList = new List<GameObject>();

        AvailableItems = new List<Item>();
        AvailableWeapons = new List<Weapon>();
        isActive = false;
    }

    // Update is called once per frame
    //UNFINISHED! UNDOCUMENTED!
    void Update()
    {
        if (selectedItemForUse != null)
        {
            Debug.Log("passedSelectionItem");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.collider.name);
                    Interactible interactible = hit.collider.gameObject.GetComponent<Interactible>();

                    string temp = "";

                    if (interactible.GetItemUsedOn(selectedItemForUse, out temp)) Debug.Log("Success");
                    Debug.Log(temp);
                    selectedItemForUse = null;
                }
            }
        }
    }

    public void Reset()
    {
        //Sets the timeflow to normal speed; unpauses
        Time.timeScale = 1;
        //Deactivates the window
        Window.SetActive(false);
    }

    //Negates the activity boolean
    public void SwitchState()
    {
        isActive ^= true;
        Window.SetActive(isActive);
        TogglePause();

    }

    public void Test()
    {
        Debug.Log("Test Successful");
    }

    private void TogglePause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            return;
        }
        Time.timeScale = 0;
    }
    #endregion

    #region Window-Specific Bloc

    #endregion
}
