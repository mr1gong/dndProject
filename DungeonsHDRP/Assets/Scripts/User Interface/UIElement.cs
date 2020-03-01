using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class UIElement: MonoBehaviour
{
    #region Fields
    public GameObject Window;
    
    protected bool isActive = false;
    #endregion   

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

    //Opens or closes the window based on the user input
    public void SwitchState(bool state)
    {
        isActive = state;
        Window.SetActive(isActive);
        TogglePause(state);
    }

    //Testing method
    public void Test()
    {
        Debug.Log("Test Successful");
    }

    //Pauses the game if a window is opened
    protected void TogglePause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            return;
        }
        Time.timeScale = 0;
    }

    //If state is true, pause, else unpause.
    protected void TogglePause(bool state)
    {
        if (!state)
        {
            Time.timeScale = 1;
            return;
        }
        Time.timeScale = 0;
    }
}
