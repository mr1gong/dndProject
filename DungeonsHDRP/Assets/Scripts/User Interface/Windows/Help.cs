#region Implementations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion
//UNFINISHED CLASS!
public class Help : UIElement
{
    #region Fields
    private static Help _HelpInstance;

    public GameObject HelpWindow;
    #endregion

    public static Help GetInstance()
    {
        if (_HelpInstance == null)
        {
            _HelpInstance = FindObjectOfType<Help>();
        }
        return _HelpInstance;
    }

    public void EnableHelp()
    {
        HelpWindow.SetActive(true);
    }

    public void DisableHelp()
    {
        HelpWindow.SetActive(false);
    }
}
