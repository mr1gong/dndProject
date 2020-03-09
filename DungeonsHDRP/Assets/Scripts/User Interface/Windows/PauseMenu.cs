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
    private static PauseMenu _PauseMenuInstance;

    public Button Resume;
    public Button Settings;
    public Button Quit;

    #endregion   

    //Loads the main menu scene
    public void QuitToMainMenu()
    {
        //Remake into a string
        SceneManager.LoadScene(0);
    }

    //Opens the settings window

    public void LaunchSettings()
    {
        UIController.GetInstance().OpenWindow(UIController.WindowNameResource.Settings);
    }

    //Closes the window and unpauses the game
    public void ResumeGame()
    {
        SwitchState(false);
        Time.timeScale = 1;
    }

    //Singleton-guarantee method
    public static PauseMenu GetInstance()
    {
        if (_PauseMenuInstance == null)
            _PauseMenuInstance = FindObjectOfType<PauseMenu>();
        return _PauseMenuInstance;
    }

    private void Start()
    {
    }
}
