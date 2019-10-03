#region Implementations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#endregion

//  UNFINISHED CLASS
public class CharacterCreation : MonoBehaviour, IUIElement
{
    #region Fields
    public static CharacterCreation CharacterCreationInstance;

    public GameObject Window;
    public Text AbilityPoints;
    public Text Strength;
    public Text Dexterity;
    public Text Constitution;
    public Text Intelligence;
    public Text Wisdom;
    public Text Charisma;

    public void Reset()
    {
        throw new System.NotImplementedException();
    }

    public void SwitchState()
    {
        throw new System.NotImplementedException();
    }
    #endregion
}
