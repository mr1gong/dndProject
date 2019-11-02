#region Implementations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class MainMenu : UIElement
{
    #region Fields
    private static MainMenu _MainMenuInstance;

    public Button ResumeButton;
    public Button NewGameButton;
    public Button SettingsButton;
    public Button HelpButton;
    public Button CreditsButton;
    public Button QuitButton;

    #endregion

    public void ResumeGame()
    {
        throw new System.Exception("Unimplemented Method!");
    }

    public void NewGame()
    {
        UIController.GetInstance().OpenWindow("CharacterCreation");
    }

    public void LaunchSettings()
    {
        UIController.GetInstance().OpenWindow("Settings");
    }

    public void LaunchHelp()
    {
        UIController.GetInstance().OpenWindow("Help");
    }

    public void LaunchCredits()
    {
        throw new System.Exception("Unimplemented Method!");
    }

    public void Quit()
    {
        Application.Quit();
    }

    //Singleton-guarantee method
    public static MainMenu GetInstance()
    {
        if (_MainMenuInstance == null)
        {
            _MainMenuInstance = FindObjectOfType<MainMenu>();
        }
        return _MainMenuInstance;
    }
}
