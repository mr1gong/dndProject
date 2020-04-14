using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : UIElement
{
    #region Fields
    private static Console _ConsoleInstance;
    public RectTransform Prime;
    public Text Text;

    private bool _TransitionOut = false;
    private bool _TransitionIn = false;

    public GameObject ConsoleWindow;
    #endregion

    void Start()
    {
        _TransitionOut = false;
        _TransitionIn = false;
    }

    void Update()
    {
        if (_TransitionIn)
        {
            TransitionIn();
        }

        if (_TransitionOut)
        {
            TransitionOut();
        }
    }

    public static Console GetInstance()
    {
        if (_ConsoleInstance == null)
        {
            _ConsoleInstance = FindObjectOfType<Console>();
        }
        return _ConsoleInstance;
    }

    public void EnableConsole()
    {
        ConsoleWindow.SetActive(true);
    }

    public void DisableConsole()
    {
        ConsoleWindow.SetActive(false);
    }

    public void StartTransitionIn()
    {
        _TransitionIn = true;
        Debug.Log($"Transitioning: {ConsoleWindow.transform.position.y}");
        Debug.Log($"Transitioning: {ConsoleWindow.transform.position.x}");
        Debug.Log("Transition Started");
    }

    public void StartTransitionOut()
    {
        _TransitionOut = true;
    }

    public void TransitionIn()
    {
        _TransitionOut = false;

        if (ConsoleWindow.transform.position.x >= 750)
        {
            _TransitionIn = false;
            return;
        }

        //ConsoleWindow.transform.position.Set(ConsoleWindow.transform.position.x + 1, ConsoleWindow.transform.position.y, ConsoleWindow.transform.position.z);
        Prime.transform.position = new Vector2(ConsoleWindow.transform.position.x + 1, 345.5f);
    }

    public void TransitionOut()
    {
        _TransitionIn = false;

        if (ConsoleWindow.transform.position.x <= 545.7283f)
        {
            _TransitionIn = false;
            return;
        }

        Prime.transform.position = new Vector2(ConsoleWindow.transform.position.x - 1, 345.5f);
    }

    public void EraseMessage()
    {
        Text = null;
    }

    public void ChangeMessage(string message)
    {
        Text.text = message;
    }
}
