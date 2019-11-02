#region Implementations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#endregion

//  UNFINISHED CLASS
public class CharacterCreation : UIElement
{
    #region Fields
    private static CharacterCreation _CharacterCreationInstance;

    public Text AbilityPoints;
    public Text Strength;
    public Text Dexterity;
    public Text Constitution;
    public Text Intelligence;
    public Text Charisma;
    #endregion

    public static CharacterCreation GetInstance()
    {
        if (_CharacterCreationInstance == null)
        {
            _CharacterCreationInstance = FindObjectOfType<CharacterCreation>();
        }
        return _CharacterCreationInstance;
    }
}
