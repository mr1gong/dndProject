using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Manager;
    private Dictionary<string, IUIElement> WindowResolver = new Dictionary<string, IUIElement>();
    // Start is called before the first frame update
    void Start()
    {
        Initialise();
    }

    //Opens UI elements based on the string input (the element's name)
    public void OpenWindow(string windowName)
    {
        //The window which is to be opened or closed
        IUIElement window = WindowResolver[windowName];
        window.SwitchState();
    }

    private void Initialise()
    {
        //Adds the static 'instances' contained in each UI Element class to the WindowResolver Dictionary
        WindowResolver.Add("CharacterCreation", CharacterCreation.CharacterCreationInstance);
        WindowResolver.Add("InspectItem", InspectItem.InspectItemInstance);
        WindowResolver.Add("Inventory", Inventory.InventoryInstance);
        WindowResolver.Add("Journal", Journal.JournalInstance);
        WindowResolver.Add("MainMenu", MainMenu.MainMenuInstance);
        WindowResolver.Add("PauseMenu", PauseMenu.PauseMenuInstance);
        WindowResolver.Add("Settings", Settings.SettingsInstance);
    }

}
