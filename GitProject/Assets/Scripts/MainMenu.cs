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
}
