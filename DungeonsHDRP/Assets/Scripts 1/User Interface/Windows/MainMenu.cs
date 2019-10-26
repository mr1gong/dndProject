#region Implementations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class MainMenu : UIElement
{
    #region Fields
    public static MainMenu MainMenuInstance;

    public Button ResumeButton;
    public Button NewGameButton;
    public Button SettingsButton;
    public Button HelpButton;
    public Button CreditsButton;
    public Button QuitButton;

    #endregion

    #region Window-Unspecific Bloc
    public void ResumeGame()
    {
        throw new System.Exception("Unimplemented Method!");
    }

    public void NewGame()
    {
        UIController.GetInstance().OpenWindow("CharacterCreationInstance");
    }

    public void LaunchSettings()
    {
        UIController.GetInstance().OpenWindow("SettingsInstance");
    }

    public void LaunchHelp()
    {
        UIController.GetInstance().OpenWindow("HelpInstance");
    }

    public void LaunchCredits()
    {
        throw new System.Exception("Unimplemented Method!");
    }

    public void Quit()
    {
        Application.Quit();
    }   
    #endregion
}
