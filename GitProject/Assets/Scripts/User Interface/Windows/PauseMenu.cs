#region Implementations
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#endregion

public class PauseMenu : UIElement
{
    #region Fields
    //The three interactable buttons on the menu window
   
    public Button Resume;
    public Button Settings;
    public Button Quit;

    #endregion   

    #region Window-Specific Bloc
    //Loads the main menu scene
    public void QuitToMainMenu()
    {
        //Remake into a string
        SceneManager.LoadScene(0);
    }

    //Opens the settings window

    public void LaunchSettings()
    {
        UIController.GetInstance().OpenWindow("SettingsInstance");
    }

    //Closes the window and unpauses the game
    public void ResumeGame()
    {
        SwitchState();
    }
    #endregion

    #region Singleton
    private static PauseMenu instance;

    public static PauseMenu GetInstance()
    {
        if (instance == null)
            instance = FindObjectOfType<PauseMenu>();
        return instance;
    }
    #endregion
}
