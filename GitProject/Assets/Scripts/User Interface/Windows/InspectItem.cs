﻿#region Implementations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class InspectItem : MonoBehaviour, IUIElement
{
    #region Fields
    public static InspectItem InspectItemInstance;

    public GameObject Window;
    public Text InspectionDetails;

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
    //NOTHING YET
    #endregion
}
