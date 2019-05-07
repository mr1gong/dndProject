using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject Buttons;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Disable()
    {
        Buttons.GetComponent<GameObject>();
        Buttons.SetActive(false);
    }

    public void Enable()
    {
        Buttons.GetComponent<GameObject>();
        Buttons.SetActive(true);
    }
}
