﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private static UIController manager;
    private Dictionary<string, UIElement> WindowResolver = new Dictionary<string, UIElement>();
    // Start is called before the first frame update
    void Start()
    {
        Initialise();
    }

    //Opens UI elements based on the string input (the element's name)
    public void OpenWindow(string windowName)
    {
        if (WindowResolver.ContainsKey(windowName))
        {        
        //The window which is to be opened or closed
        UIElement window = WindowResolver[windowName];
        window.SwitchState(true);
        }
        else
        {
            throw new Exception("Window not found");
        }
    }

    public void SwitchWindow(string windowName)
    {
        if (WindowResolver.ContainsKey(windowName))
        {
            //The window which is to be opened or closed
            UIElement window = WindowResolver[windowName];
            window.SwitchState();
        }
        else
        {
            throw new Exception("Window not found");
        }
    }


    public static UIController GetInstance()
    {
        if(manager != null)
        {
            return manager;
        }
        return new UIController();
    }

    private UIController()
    {
        WindowResolver = new Dictionary<string, UIElement>();
        manager = this;
    }

    private void Initialise()
    {
        //Adds the static 'instances' contained in each UI Element class to the WindowResolver Dictionary
        WindowResolver.Add("CharacterCreation", CharacterCreation.GetInstance());
        WindowResolver.Add("DeathSequence", DeathSequence.GetInstance());
        WindowResolver.Add("InspectItem", InspectItem.GetInstance());
        WindowResolver.Add("PauseMenu", PauseMenu.GetInstance());
        WindowResolver.Add("Inventory", Inventory.GetInstance());
        WindowResolver.Add("MainMenu", MainMenu.GetInstance());
        WindowResolver.Add("Settings", Settings.GetInstance());
        WindowResolver.Add("Journal", Journal.GetInstance());
        WindowResolver.Add("Help", Help.GetInstance());
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