using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Author("Makovec","preAlpha-V0.2")]
public class GeneralFunctionManager : MonoBehaviour
{
    public GameObject UICanvasPrefab;

    #region Initialize
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(UICanvasPrefab);
    }
    #endregion
    #region Periodic
    // Update is called once per frame
    void Update()
    {
        #region UI 
        //Checks Keyboard Input
        //Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIController.GetInstance().OpenWindow(WindowNameResource.PauseMenu);
        }
        //Journal
        if (Input.GetKeyDown(KeyCode.J))
        {
            UIController.GetInstance().OpenWindow(WindowNameResource.Journal);
        }
        //Inventory
        if (Input.GetKeyDown(KeyCode.I))
        {
            UIController.GetInstance().OpenWindow(WindowNameResource.Inventory);
        }
        //TODO: Settings
        //if (Input.GetAxis("Inventory") != 0) { }
        #endregion
    }

    
    #endregion
}
