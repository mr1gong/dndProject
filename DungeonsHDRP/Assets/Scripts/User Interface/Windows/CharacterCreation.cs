#region Implementations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
#endregion

//  UNFINISHED CLASS
public class CharacterCreation : UIElement
{
    #region Fields
    private static CharacterCreation _CharacterCreationInstance;

    public Text ProgressionPoints;
    public Text Strength;
    public Text Dexterity;
    public Text Constitution;
    public Text Intelligence;
    public Text Wisdom;
    public Text Charisma;

    public Button StartGameButton;
    #endregion

    void Start()
    {
        StartGameButton.interactable = false;
    }

    public static CharacterCreation GetInstance()
    {
        if (_CharacterCreationInstance == null)
        {
            _CharacterCreationInstance = FindObjectOfType<CharacterCreation>();
        }
        return _CharacterCreationInstance;
    }

    public void IncrementStrength()
    {
        Debug.Log("Strength Button Pressed");
        if (SpendPoint(Strength))
            Increment(Strength.GetComponent<Text>());
    }

    public void IncrementDexterity()
    {
        Debug.Log("Dexterity Button Pressed");
        if (SpendPoint(Dexterity))
            Increment(Dexterity.GetComponent<Text>());
    }

    public void IncrementConstitution()
    {
        Debug.Log("Constitution Button Pressed");
        if (SpendPoint(Constitution))
            Increment(Constitution.GetComponent<Text>());
    }

    public void IncrementIntelligence()
    {
        Debug.Log("Intelligence Button Pressed");
        if (SpendPoint(Intelligence))
            Increment(Intelligence.GetComponent<Text>());
    }
    public void IncrementWisdom()
    {
        Debug.Log("Wisdom Button Pressed");
        if (SpendPoint(Wisdom))
            Increment(Wisdom.GetComponent<Text>());
    }

    public void IncrementCharisma()
    {
        Debug.Log("Charisma Button Pressed");
        if (SpendPoint(Charisma))
            Increment(Charisma.GetComponent<Text>());
    }

    public void DecrementStrength()
    {
        Debug.Log("Strength Button Pressed");
        if (GainPoint(Strength))
            Decrement(Strength.GetComponent<Text>());
    }

    public void DecrementDexterity()
    {
        Debug.Log("Dexterity Button Pressed");
        if (GainPoint(Dexterity))
            Decrement(Dexterity.GetComponent<Text>());
    }

    public void DecrementConstitution()
    {
        Debug.Log("Constitution Button Pressed");
        if (GainPoint(Constitution))
            Decrement(Constitution.GetComponent<Text>());
    }

    public void DecrementIntelligence()
    {
        Debug.Log("Intelligence Button Pressed");
        if (GainPoint(Intelligence))
            Decrement(Intelligence.GetComponent<Text>());
    }
    public void DecrementWisdom()
    {
        Debug.Log("Wisdom Button Pressed");
        if (GainPoint(Wisdom))
            Decrement(Wisdom.GetComponent<Text>());
    }

    public void DecrementCharisma()
    {
        Debug.Log("Charisma Button Pressed");
        if (GainPoint(Charisma))
            Decrement(Charisma.GetComponent<Text>());
    }

    public void QuitMainMenu()
    {
        SaveCharacter();
        SceneLoader.ToLoadingScreen("Prison");
    }

    private void Decrement(Text input)
    {
        int value = int.Parse(input.text);
        value--;
        input.text = value.ToString();
    }


    private void Increment(Text input)
    {
        int value = int.Parse(input.text);
        value++;
        input.text = value.ToString();
    }

    private bool SpendPoint(Text ability)
    {
        if (int.Parse(ProgressionPoints.text) <= 0) return false;
        if (int.Parse(ability.text) >= 20) return false;
        Decrement(ProgressionPoints);

        if (int.Parse(ProgressionPoints.text) > 0)
            StartGameButton.interactable = false;
        else StartGameButton.interactable = true;

        return true;
    }

    private bool GainPoint(Text ability)
    {
        if (int.Parse(ProgressionPoints.text) >= 8) return false;
        if (int.Parse(ability.text) <= 8) return false;
        Increment(ProgressionPoints);

        if (int.Parse(ProgressionPoints.text) > 0)
            StartGameButton.interactable = false;
        else StartGameButton.interactable = true;

        return true;
    }

    private void SaveCharacter()
    {
        File.WriteAllText("CharacterSave.txt", getParameters());
        string getParameters()
        {
            string output = null;
            output += Strength.text;
            output += ",";
            output += Dexterity.text;
            output += ",";
            output += Constitution.text;
            output += ",";
            output += Intelligence.text;
            output += ",";
            output += Wisdom.text;
            output += ",";
            output += Charisma.text;
            Debug.Log("Saving: '" + output + "'");
            return output;
        }
    }
}
