#region Implementations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#endregion
//UNFINISHED CLASS
public class InspectItem : UIElement
{
    #region Fields
    private static InspectItem _InspectItemInstance;

    public Text InspectionDetails;
    #endregion

    //Singleton-guarantee method
    public static InspectItem GetInstance()
    {
        if (_InspectItemInstance == null)
        {
            _InspectItemInstance = FindObjectOfType<InspectItem>();
        }
        return _InspectItemInstance;
    }
}
