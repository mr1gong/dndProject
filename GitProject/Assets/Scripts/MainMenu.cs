//Author: Novak

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioMixer MainMenuMixer;
    public GameObject CharacterCreation;
    public GameObject Buttons;
    public GameObject SettingsMenu;
    public Dropdown resolutionDropdown;
    public Text ProgressionPoints;
    public Text Strength;
    public Text Dexterity;
    public Text Constitution;
    public Text Intelligence;
    public Text Wisdom;
    public Text Charisma;

    private Resolution[] resolutions;

    private void Start()
    {
        int screenResolutionIdex = 0;
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(toList(resolutions));

        resolutionDropdown.value = screenResolutionIdex;
        resolutionDropdown.RefreshShownValue();

        List<string> toList(Resolution[] input)
        {
            List<string> output = new List<string>();
            for (int i = 0; i < resolutions.Length; i++)
            {
                string item = resolutions[i].width + " by " + resolutions[i].height;
                output.Add(item);

                if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    screenResolutionIdex = i;
                }
            }
            return output;
        }
    }

    public void SetVolume(float inputVolume)
    {
        MainMenuMixer.SetFloat("MasterVolume", inputVolume);

    }

    public void EnableCharacterCreation()
    {
        CharacterCreation.GetComponent<GameObject>();
        CharacterCreation.SetActive(true);
    }

    public void DisableCharacterCreation()
    {
        CharacterCreation.GetComponent<GameObject>();
        CharacterCreation.SetActive(false);
    }

    public void DisableButtons()
    {
        Buttons.GetComponent<GameObject>();
        Buttons.SetActive(false);
    }

    public void EnableButtons()
    {
        Buttons.GetComponent<GameObject>();
        Buttons.SetActive(true);
    }

    public void EnableSettings()
    {
        SettingsMenu.GetComponent<GameObject>();
        SettingsMenu.SetActive(true);
    }

    public void DisableSettings()
    {
        SettingsMenu.GetComponent<GameObject>();
        SettingsMenu.SetActive(false);
    }

    public void SetGraphicsQuality (int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void TriggerFullscreenMode(bool input)
    {
        Screen.fullScreen = input;
    }

    public void SetResolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void IncrementStrength()
    {
        Debug.Log("Strength Button Pressed");
        if (SpendPoint())
            Increment(Strength.GetComponent<Text>());
    }

    public void IncrementDexterity()
    {
        Debug.Log("Dexterity Button Pressed");
        if (SpendPoint())
            Increment(Dexterity.GetComponent<Text>());
    }

    public void IncrementConstitution()
    {
        Debug.Log("Constitution Button Pressed");
        if (SpendPoint())
            Increment(Constitution.GetComponent<Text>());
    }

    public void IncrementIntelligence()
    {
        Debug.Log("Intelligence Button Pressed");
        if (SpendPoint())
            Increment(Intelligence.GetComponent<Text>());
    }
    public void IncrementWisdom()
    {
        Debug.Log("Wisdom Button Pressed");
        if (SpendPoint())
            Increment(Wisdom.GetComponent<Text>());
    }

    public void IncrementCharisma()
    {
        Debug.Log("Charisma Button Pressed");
        if (SpendPoint())
            Increment(Charisma.GetComponent<Text>());
    }

    public void DecrementStrength()
    {
        Debug.Log("Strength Button Pressed");
        if (int.Parse(Strength.GetComponent<Text>().text) <= 10)
            return;

        if (GainPoint())
            Decrement(Strength.GetComponent<Text>());
    }

    public void DecrementDexterity()
    {
        Debug.Log("Dexterity Button Pressed");
        if (int.Parse(Dexterity.GetComponent<Text>().text) <= 10)
            return;

        if (GainPoint())
            Decrement(Dexterity.GetComponent<Text>());
    }

    public void DecrementConstitution()
    {
        Debug.Log("Constitution Button Pressed");
        if (int.Parse(Constitution.GetComponent<Text>().text) <= 10)
            return;

        if (GainPoint())
            Decrement(Constitution.GetComponent<Text>());
    }

    public void DecrementIntelligence()
    {
        Debug.Log("Intelligence Button Pressed");
        if (int.Parse(Intelligence.GetComponent<Text>().text) <= 10)
            return;

        if (GainPoint())
            Decrement(Intelligence.GetComponent<Text>());
    }
    public void DecrementWisdom()
    {
        Debug.Log("Wisdom Button Pressed");
        if (int.Parse(Wisdom.GetComponent<Text>().text) <= 10)
            return;

        if (GainPoint())
            Decrement(Wisdom.GetComponent<Text>());
    }

    public void DecrementCharisma()
    {
        Debug.Log("Charisma Button Pressed");
        if (int.Parse(Charisma.GetComponent<Text>().text) <= 10)
            return;

        if (GainPoint())
            Decrement(Charisma.GetComponent<Text>());
    }

    public void SaveCharacter()
    {
        string output = null;
        output = Strength.GetComponent<Text>().text +
            "," + Dexterity.GetComponent<Text>().text +
            "," + Constitution.GetComponent<Text>().text +
            "," + Intelligence.GetComponent<Text>().text +
            "," + Wisdom.GetComponent<Text>().text +
            "," + Charisma.GetComponent<Text>().text;

        System.IO.File.WriteAllText("CharacterData.txt", output);
        Debug.Log("Character Saved!");
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

    private bool SpendPoint()
    {
        if (int.Parse(ProgressionPoints.text) <= 0) return false;
        Decrement(ProgressionPoints);
        return true;
    }

    private bool GainPoint()
    {
        if (int.Parse(ProgressionPoints.text) >= 8) return false;
        Increment(ProgressionPoints);
        return true;
    }
}
