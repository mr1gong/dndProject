using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            UIController.GetInstance().OpenWindow(UIController.PauseMenuWindowName);
        }
        //Journal
        if (Input.GetAxis("Journal") != 0)
        {
            UIController.GetInstance().OpenWindow(UIController.JournalWindowName);
        }
        //Inventory
        if (Input.GetAxis("Inventory") != 0)
        {
            UIController.GetInstance().OpenWindow(UIController.InventoryWindowName);
        }
        //TODO: Settings
        //if (Input.GetAxis("Inventory") != 0) { }
        #endregion
    }

    
    #endregion
}
