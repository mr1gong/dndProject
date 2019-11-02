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
    #endregion

    public static Help GetInstance()
    {
        if (_HelpInstance == null)
        {
            _HelpInstance = FindObjectOfType<Help>();
        }
        return _HelpInstance;
    }
}
