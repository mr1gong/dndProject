#region Implementations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class Journal : UIElement
{
    #region Fields
    public static Journal JournalInstance;

    public Text MainObjective;
    public Text CurrentObjective;

    #endregion



    #region Window-Specific Bloc
    //Overrides the body of the Text Object with the string input; changes the primary objective in the journal
    public void ChangeMainObjective(string input)
    {
        ClearText(MainObjective);
        MainObjective.text = input;
    }

    //Overrides the body of the Text Object with the string input; changes the secondary objective in the journal
    public void ChangeSecondaryObjective(string input)
    {
        ClearText(CurrentObjective);
        CurrentObjective.text = input;
    }

    //Deletes the body of the input Text Object
    public void ClearText(Text input)
    {
        input = null;
    }

    
    #endregion
}
