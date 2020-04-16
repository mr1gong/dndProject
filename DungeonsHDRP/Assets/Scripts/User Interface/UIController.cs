using System;
using System.Collections.Generic;
using UnityEngine;
[Author("Novák", "preAlpha-V0.2")]
public class UIController : MonoBehaviour
{
    private bool Initialized = false;
    public enum WindowNameResource
    {
        CharacterCreation = 1,
        DeathSequence = 2,
        InspectItem = 3,
        PauseMenu = 4,
        Inventory = 5,
        MainMenu = 6,
        Settings = 7,
        Journal = 8,
        Help = 9,
        Dialogue = 10,
        VitalsDisplay = 11
    }

    private static UIController _UIControllerInstance;
    private Dictionary<int, UIElement> WindowResolver = new Dictionary<int, UIElement>();

    // Start is called before the first frame update
    void Start()
    {
        if (!Initialized)
        {
            Initialise();
        }
    }

    //Opens UI elements based on the string input (the element's name)
    public void OpenWindow(WindowNameResource windowName)
    {
        if (WindowResolver.ContainsKey((int)windowName))
        {        
        //The window which is to be opened or closed
        UIElement window = WindowResolver[(int)windowName];
        window.SwitchState(true);
        }
        else
        {
            foreach (int key in WindowResolver.Keys) Debug.Log(key);
            throw new Exception("Window not found: " + windowName);
        }
    }

    public void SwitchWindow(WindowNameResource windowName)
    {
        if (WindowResolver.ContainsKey((int)windowName))
        {
            //The window which is to be opened or closed
            UIElement window = WindowResolver[(int)windowName];
            window.SwitchState();
        }
        else
        {
            throw new Exception("Window not found");
        }
    }

    /*public static UIController GetInstance()
    {
        if(_UIControllerInstance != null)
        {
            return _UIControllerInstance;
        }
        return new UIController();
    }*/

    public static UIController GetInstance()
    {
        if (_UIControllerInstance == null)
        {
            _UIControllerInstance = FindObjectOfType<UIController>();
        }
        return _UIControllerInstance;
    }

    private UIController()
    {
        WindowResolver = new Dictionary<int, UIElement>();
        _UIControllerInstance = this;
    }

    private void Initialise()
    {
        //Adds the static 'instances' contained in each UI Element class to the WindowResolver Dictionary
        WindowResolver.Add((int)WindowNameResource.CharacterCreation, CharacterCreation.GetInstance());
        WindowResolver.Add((int)WindowNameResource.DeathSequence, DeathSequence.GetInstance());
        WindowResolver.Add((int)WindowNameResource.InspectItem, InspectItem.GetInstance());
        WindowResolver.Add((int)WindowNameResource.PauseMenu, PauseMenu.GetInstance());
        WindowResolver.Add((int)WindowNameResource.Inventory, InventoryInterface.GetInstance());
        WindowResolver.Add((int)WindowNameResource.MainMenu, MainMenu.GetInstance());
        WindowResolver.Add((int)WindowNameResource.Settings, Settings.GetInstance());
        WindowResolver.Add((int)WindowNameResource.Journal, Journal.GetInstance());
        WindowResolver.Add((int)WindowNameResource.Help, Help.GetInstance());
        WindowResolver.Add((int)WindowNameResource.Dialogue, DialogueReader.GetInstance());

        foreach (var v in WindowResolver)
        {
            Debug.Log(v.Key);
        }
        Initialized = true;
    }
}

#region Unimplemented
//Window name constants
/*public const string CharacterCreationWindowName = "CharacterCreation";
public const string InspectItemWindowName = "InspectItem";
public const string InventoryWindowName = "Inventory";
public const string JournalWindowName = "Journal";
public const string MainMenuWindowName = "MainMenu";
public const string PauseMenuWindowName = "PauseMenu";
public const string SettingsWindowName = "Settings";*/
#endregion