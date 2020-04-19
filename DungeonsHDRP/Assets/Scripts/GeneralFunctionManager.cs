
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
            UIController.GetInstance().SwitchWindow(UIController.WindowNameResource.PauseMenu);
        }
        //Journal
        if (Input.GetKeyDown(KeyCode.J))
        {
            UIController.GetInstance().SwitchWindow(UIController.WindowNameResource.Journal);
        }
        //Inventory
        if (Input.GetKeyDown(KeyCode.I))
        {
            UIController.GetInstance().SwitchWindow(UIController.WindowNameResource.Inventory);
        }

        //RollDisplay
        if (Input.GetKeyDown(KeyCode.P))
        {
            UIController.GetInstance().SwitchWindow(UIController.WindowNameResource.RollDisplay);
        }

        //Settings
        if (Input.GetKeyDown(KeyCode.K))
        {
            UIController.GetInstance().SwitchWindow(UIController.WindowNameResource.Settings);
        }

        //TODO: Settings
        //if (Input.GetAxis("Inventory") != 0) { }
        #endregion
    }

    
    #endregion
}
