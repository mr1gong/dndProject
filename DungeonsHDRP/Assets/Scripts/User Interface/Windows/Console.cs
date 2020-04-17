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
    public Vector3 _OriginCoord;
    private bool _TransitionOut = false;
    private bool _TransitionIn = false;
    private int _TimeOut = 1000;
    private bool _IsTimeout = false;

    public GameObject ConsoleWindow;
    #endregion

    void Start()
    {
        Prime.localPosition = new Vector3(GetComponent<RectTransform>().anchorMax.x- GetComponent<RectTransform>().rect.width/2, Prime.localPosition.y, Prime.localPosition.z);
        _OriginCoord = Prime.localPosition;
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

        if (_TimeOut != 0)
        {
            _TimeOut--;
        }
        
        if (_TimeOut <= 0 && _IsTimeout)
        {
            Debug.Log("Timeout!");
            StartTransitionOut();
            _IsTimeout = false;
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
    }

    public void StartTransitionIn(string message)
    {
        Text.text = message;
        _TransitionIn = true;
    }

    public void StartTransitionOut()
    {
        _TransitionOut = true;
    }

    private void TransitionIn()
    {
        _TransitionOut = false;
        //REAL + OFFSET {CHANGE ONLY OFFSET}
        if (Prime.localPosition.x >= _OriginCoord.x+Prime.rect.width*2f)
        {
            Debug.Log("Transition Finished");
            _TimeOut = 1000;
            _IsTimeout = true;
            _TransitionIn = false;
            return;
        }

        //ConsoleWindow.transform.position.Set(ConsoleWindow.transform.position.x + 1, ConsoleWindow.transform.position.y, ConsoleWindow.transform.position.z);
        Prime.transform.Translate(10, 0, 0);
    }

    private void TransitionOut()
    {
        _TimeOut = 0;
        _IsTimeout = false;
        _TransitionIn = false;
        //REAL + OFFSET {CHANGE ONLY OFFSET}
        if (Prime.localPosition.x <= _OriginCoord.x)
        {
            _TransitionIn = false;
            return;
        }

        Prime.transform.Translate(-10, 0, 0);
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
