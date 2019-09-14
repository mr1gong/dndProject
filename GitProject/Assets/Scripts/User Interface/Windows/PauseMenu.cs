#region Implementations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#endregion

public class PauseMenu : MonoBehaviour, IUIElement
{
    #region Fields
    //The three interactable buttons on the menu window
    public GameObject Window;
    public Button Resume;
    public Button Settings;
    public Button Quit;

    private bool isActive;
    #endregion

    #region Window-Unspecific Bloc
    // Start is called before the first frame update
    void Start()
    {
        Window.GetComponent<GameObject>();
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void Reset()
    {
        //Sets the timeflow to normal speed; unpauses
        Time.timeScale = 1;
        //Deactivates the window
        Window.SetActive(false);
    }

    //Negates the activity boolean
    public void SwitchState()
    {
        isActive ^= true;
        Window.SetActive(isActive);
        TogglePause();

    }

    public void Test()
    {
        Debug.Log("Test Successful");
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
        UIController.Manager.OpenWindow("Settings");
    }

    //Closes the window and unpauses the game
    public void ResumeGame()
    {
        SwitchState();
    }
    #endregion
}
