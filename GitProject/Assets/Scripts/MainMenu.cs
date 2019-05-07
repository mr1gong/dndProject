using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer MainMenuMixer;
    public GameObject Buttons;
    public GameObject SettingsMenu;
    // Start is called before the first frame update
    
    //Adjusts the game volume in accordance with the main menu settings volume slider
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
}
