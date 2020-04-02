#region Implementations
using UnityEngine;
using UnityEngine.UI;
#endregion

public class MainMenu : UIElement
{
    #region Fields
    private static MainMenu _MainMenuInstance;

    public Button NewGameButton;
    public Button SettingsButton;
    public Button HelpButton;
    public Button CreditsButton;
    public Button QuitButton;

    public GameObject Credits;
    public Animator Animation;

    #endregion

    public void NewGame()
    {
        UIController.GetInstance().OpenWindow(UIController.WindowNameResource.CharacterCreation);
    }

    public void LaunchSettings()
    {
        UIController.GetInstance().OpenWindow(UIController.WindowNameResource.Settings);
    }

    public void LaunchHelp()
    {
        UIController.GetInstance().OpenWindow(UIController.WindowNameResource.Help);
    }

    public void LaunchCredits()
    {
        Credits.GetComponent<GameObject>();
        Animation.SetTrigger("StartCredits");
        Credits.SetActive(true);
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
