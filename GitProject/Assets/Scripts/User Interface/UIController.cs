using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Manager;
    private Dictionary<string, IUIElement> WindowResolver = new Dictionary<string, IUIElement>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Opens UI elements based on the string input (the element's name)
    public void OpenWindow(string windowName)
    {
        //The window which is to be opened or closed
        IUIElement window = WindowResolver[windowName];
        window.SwitchState();
    }

    /*private void ToggleWindow(int index)
    {
        Windows[index].GetComponent<GameObject>();
        //Inverts the enabled-disabled status
        Windows[index].SetActive(!Windows[index].activeSelf);
        Debug.Log($"UI Item Number {index} Toggled");
    }*/

    private void TogglePause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            return;
        }
        Time.timeScale = 0;
    }
}
