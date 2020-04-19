using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollDisplay : UIElement
{
    #region Fields
    private static RollDisplay _RollDisplayInstance;

    public GameObject RollDisplayWindow;
    public Text Roll1;
    public Text Roll2;
    public Text Roll3;
    public Text Roll4;
    #endregion

    void Start()
    {
        Roll1.text = null;
        Roll2.text = null;
        Roll3.text = null;
        Roll4.text = null;
    }

    [HideInInspector]
    public static RollDisplay GetInstance()
    {
        if (_RollDisplayInstance == null)
        {
            _RollDisplayInstance = FindObjectOfType<RollDisplay>();
        }
        return _RollDisplayInstance;
    }

    public void ShowRoll(int roll)
    {
        Roll4.text = Roll3.text;
        Roll3.text = Roll2.text;
        Roll2.text = Roll1.text;
        Roll1.text = roll.ToString();
    } 

    public void EnableHelp()
    {
        RollDisplayWindow.SetActive(true);
    }

    public void DisableHelp()
    {
        RollDisplayWindow.SetActive(false);
    }
}
