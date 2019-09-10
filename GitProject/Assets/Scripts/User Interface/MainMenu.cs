#region Implementations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#endregion

public class MainMenu : MonoBehaviour, IUIElement
{
    #region Fields
    //The three interactable buttons on the menu window
    public GameObject MainMenuWindow;
    public Button Resume;
    public Button Settings;
    public Button Quit;

    private bool isActive;
    #endregion

    #region Shared Part
    // Start is called before the first frame update
    void Start()
    {
        MainMenuWindow.GetComponent<GameObject>();
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void Reset()
    {
        throw new System.NotImplementedException();
    }

    //Negates the activity boolean
    public void SwitchState()
    {
        isActive ^= true;
        MainMenuWindow.SetActive(isActive);

    }
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
        UIController.Manager.OpenWindow("Settings");
    }
}
