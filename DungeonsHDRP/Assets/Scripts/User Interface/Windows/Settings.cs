#region Implementations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
#endregion

public class Settings : UIElement
{
    #region Fields
    private static Settings _SettingsInstance;

    public AudioMixer Mixer;
    public Dropdown ResolutionDropdown;

    private Resolution[] resolutions;
    #endregion

    //Handles the dropdown window-element presenting the available resolutions
    private void TackleResolutions()
    {
        int screenResolutionIdex = 0;
        //Gets all the available resolutions from the machine
        resolutions = Screen.resolutions;
        ResolutionDropdown.ClearOptions();
        ResolutionDropdown.AddOptions(toList(resolutions));

        //Sets the default value to the native resolution (if such exists)
        ResolutionDropdown.value = screenResolutionIdex;
        ResolutionDropdown.RefreshShownValue();

        //Method converting the available resolutions array (of the type Resolutions) into a string List
        List<string> toList(Resolution[] input)
        {
            List<string> outputList = new List<string>();
            for (int iterator = 0; iterator < resolutions.Length; iterator++)
            {
                string item = resolutions[iterator].width + " by " + resolutions[iterator].height;
                outputList.Add(item);

                //Sets the resolution index to the index of the screen resolution from the list above matching the native resolution (if such exists)
                if (resolutions[iterator].width == Screen.currentResolution.width &&
                    resolutions[iterator].height == Screen.currentResolution.height)
                {
                    screenResolutionIdex = iterator;
                }
            }
            return outputList;
        }
    }

    //Changes the volume for the MasterVolume mixer to the input value
    public void SetVolume(float inputVolume)
    {
        Mixer.SetFloat("MasterVolume", inputVolume);

    }

    //Changes the graphics quality (list of the graphics options may be found in the User Settings in the Unity Editor)
    public void SetGraphicsQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    //Triggers fullscreen according to a tickbox state
    public void TriggerFullscreenMode(bool input)
    {
        Screen.fullScreen = input;
    }

    #region Singleton
    public static Settings SettingsInstance;

    public static Settings GetInstance()
    {
        if (_SettingsInstance == null)
        {
            _SettingsInstance = FindObjectOfType<Settings>();
        }
        return _SettingsInstance;
    }
    #endregion
}
