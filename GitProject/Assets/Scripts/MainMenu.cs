//Author: Novak

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioMixer MainMenuMixer;
    public GameObject Buttons;
    public GameObject SettingsMenu;
    public Dropdown resolutionDropdown;
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
        Debug.Log(Strength.GetComponent<Text>().text);
        int value = int.Parse(Strength.GetComponent<Text>().text);
        Debug.Log(value);
        value++;
        Debug.Log(value);
        Strength.GetComponent<Text>().text = value.ToString();
    }

    public void IncrementDexterity()
    {
        Debug.Log("Dexterity Button Pressed");
        Debug.Log(Dexterity.GetComponent<Text>().text);
        int value = int.Parse(Dexterity.GetComponent<Text>().text);
        Debug.Log(value);
        value++;
        Debug.Log(value);
        Dexterity.GetComponent<Text>().text = value.ToString();
    }

    public void IncrementConstitution()
    {
        Debug.Log("Constitution Button Pressed");
        Debug.Log(Constitution.GetComponent<Text>().text);
        int value = int.Parse(Constitution.GetComponent<Text>().text);
        Debug.Log(value);
        value++;
        Debug.Log(value);
        Constitution.GetComponent<Text>().text = value.ToString();
    }

    public void IncrementIntelligence()
    {
        Debug.Log("Intelligence Button Pressed");
        Debug.Log(Intelligence.GetComponent<Text>().text);
        int value = int.Parse(Intelligence.GetComponent<Text>().text);
        Debug.Log(value);
        value++;
        Debug.Log(value);
        Intelligence.GetComponent<Text>().text = value.ToString();
    }
    public void IncrementWisdom()
    {
        Debug.Log("Wisdom Button Pressed");
        Debug.Log(Wisdom.GetComponent<Text>().text);
        int value = int.Parse(Wisdom.GetComponent<Text>().text);
        Debug.Log(value);
        value++;
        Debug.Log(value);
        Wisdom.GetComponent<Text>().text = value.ToString();
    }

    public void IncrementCharisma()
    {
        Debug.Log("Charisma Button Pressed");
        Debug.Log(Charisma.GetComponent<Text>().text);
        int value = int.Parse(Charisma.GetComponent<Text>().text);
        Debug.Log(value);
        value++;
        Debug.Log(value);
        Charisma.GetComponent<Text>().text = value.ToString();
    }

    public void DecrementStrength()
    {
        Debug.Log("Strength Button Pressed");
        Debug.Log(Strength.GetComponent<Text>().text);
        int value = int.Parse(Strength.GetComponent<Text>().text);
        Debug.Log(value);
        value--;
        Debug.Log(value);
        Strength.GetComponent<Text>().text = value.ToString();
    }

    public void DecrementDexterity()
    {
        Debug.Log("Dexterity Button Pressed");
        Debug.Log(Dexterity.GetComponent<Text>().text);
        int value = int.Parse(Dexterity.GetComponent<Text>().text);
        Debug.Log(value);
        value--;
        Debug.Log(value);
        Dexterity.GetComponent<Text>().text = value.ToString();
    }

    public void DecrementConstitution()
    {
        Debug.Log("Constitution Button Pressed");
        Debug.Log(Constitution.GetComponent<Text>().text);
        int value = int.Parse(Constitution.GetComponent<Text>().text);
        Debug.Log(value);
        value--;
        Debug.Log(value);
        Constitution.GetComponent<Text>().text = value.ToString();
    }

    public void DecrementIntelligence()
    {
        Debug.Log("Intelligence Button Pressed");
        Debug.Log(Intelligence.GetComponent<Text>().text);
        int value = int.Parse(Intelligence.GetComponent<Text>().text);
        Debug.Log(value);
        value--;
        Debug.Log(value);
        Intelligence.GetComponent<Text>().text = value.ToString();
    }
    public void DecrementWisdom()
    {
        Debug.Log("Wisdom Button Pressed");
        Debug.Log(Wisdom.GetComponent<Text>().text);
        int value = int.Parse(Wisdom.GetComponent<Text>().text);
        Debug.Log(value);
        value--;
        Debug.Log(value);
        Wisdom.GetComponent<Text>().text = value.ToString();
    }

    public void DecrementCharisma()
    {
        Debug.Log("Charisma Button Pressed");
        Debug.Log(Charisma.GetComponent<Text>().text);
        int value = int.Parse(Charisma.GetComponent<Text>().text);
        Debug.Log(value);
        value--;
        Debug.Log(value);
        Charisma.GetComponent<Text>().text = value.ToString();
    }
}
