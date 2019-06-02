/**
 * Author: Marek Makovec (1 + debug) & Jindrich Novak
 **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject Inventory;   private List<GameObject> SlotList = new List<GameObject>();
    public Text CurrentObjective;  private List<GameObject> UiList = new List<GameObject>();

    public GameObject QuestSlot0;  public Item Item0;      private Image QuestSlot0Image;
    public GameObject QuestSlot1;  public Item Item1;      private Image QuestSlot1Image;
    public GameObject QuestSlot2;  public Item Item2;      private Image QuestSlot2Image;

    public GameObject WeaponSlot0; public Weapon weapon0;  private Image WeaponSlot0Image;
    public GameObject WeaponSlot1; public Weapon weapon1;  private Image WeaponSlot1Image;
    public GameObject WeaponSlot2; public Weapon weapon2;  private Image WeaponSlot2Image;

    public GameObject PauseMenu;   public Button Resume;   public AudioMixer Mixer;
    public GameObject Journal;     public Button Settings; public Button CloseSettings;
    public Text MainObjective;     public Button quit;     public GameObject SettingsMenu;

    public Dropdown resolutionDropdown;
    public GameObject InspectionWindow;
    public Text InspectionDetails;

    private Item selectedItemForUse;


    //List of all available resolutions
    private Resolution[] resolutions;
    //List of all UI components indexed with an integer
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
        Reinitialise();
        CheckInput();
        TackleResolutions();
        
        //DisableInspectionWindow();


        //Use Selected Item on Interactible
        if(selectedItemForUse != null || true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Input.GetMouseButtonDown(0)) {
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.collider.name);
                    Interactible interactible = hit.collider.gameObject.GetComponent<Interactible>();
                    if (interactible == null) { interactible = hit.collider.gameObject.GetComponent<Lockable>(); }
                    if (interactible == null) { interactible = hit.collider.gameObject.GetComponent<DoorScript>(); }
                    string temp = "";

                    if (interactible.GetItemUsedOn(selectedItemForUse, out temp)) Debug.Log("Success");
                    Debug.Log(temp);
                    selectedItemForUse = null;
                }
            }

        }

    }

    public void Inspect(int index)
    {
        switch (index)
        {
            case 0:
                InspectionWindow.SetActive(true);
                InspectionDetails.text = Item0.Description;
                return;
            case 1:
                InspectionWindow.SetActive(true);
                InspectionDetails.text = Item1.Description;
                return;
            case 2:
                InspectionWindow.SetActive(true);
                InspectionDetails.text = Item2.Description;
                return;
            default:
                throw new System.Exception("Ivalid Item Index");
        }
    }

    public void SetVolume(float inputVolume)
    {
        Mixer.SetFloat("MasterVolume", inputVolume);

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
        UiList.Add(PauseMenu);
        UiList.Add(SettingsMenu);
        UiList.Add(InspectionWindow);

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

    //By Makovec
    public bool CheckInventorySpace()
    {
        bool slot0 = Item0 == null; bool slot1 = Item1 == null; bool slot2 = Item2 == null;
        return slot0 || slot1 || slot2;
    }
    
    public void ResumeGame()
    {
        ToggleWindow(2);
        //TogglePause();
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void Test()
    {
        Debug.Log("Test Successful");
    }

    public void ToggleSettings()
    {
        ToggleWindow(2);
        ToggleWindow(3);
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

    private void DisableInspectionWindow()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            InspectionWindow.SetActive(false);
        }
    }

    private void Reinitialise()
    {
        for (int i = 0; i < UiList.Count; i++)
        {
            UiList[i].GetComponent<GameObject>();
        }
    }

    private void ToggleWindow(int index)
    {
        Windows[index].GetComponent<GameObject>();
        //Inverts the enabled-disabled status
        Windows[index].SetActive(!Windows[index].activeSelf);
        Debug.Log($"UI Item Number {index} Toggled");
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

    private void CheckInput()
    {
        if (Input.GetButtonDown("Journal"))
        {
            ToggleWindow(0);
            //TogglePause();
        }

        if (Input.GetButtonDown("Inventory"))
        {
            ToggleWindow(1);
            //TogglePause();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            ToggleWindow(2);
            //TogglePause();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            ToggleWindow(3);
            //TogglePause();
        }
    }
    
    private void TackleResolutions()
    {
        int screenResolutionIdex = 0;
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(toList(resolutions));

        resolutionDropdown.value = screenResolutionIdex;
        resolutionDropdown.RefreshShownValue();

        List<string> toList(Resolution[] input)
        {
            List<string> output = new List<string>();
            for (int i = 0; i < resolutions.Length; i++)
            {
                string item = resolutions[i].width + " by " + resolutions[i].height;
                output.Add(item);

                if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    screenResolutionIdex = i;
                }
            }
            return output;
        }
    }
    public void TryUseItem(int itemSlotIndex)
    {
        Debug.Log("1");
        switch(itemSlotIndex)
        {
            //Set selected item
            case 0: selectedItemForUse = Item0; break;
            case 1: selectedItemForUse = Item1; break;
            case 2: selectedItemForUse = Item2; break;
            default: throw new System.NotImplementedException();
        }
        ToggleWindow(1);



         
    }
    private void CheckInventoryButtons() { } 

}
