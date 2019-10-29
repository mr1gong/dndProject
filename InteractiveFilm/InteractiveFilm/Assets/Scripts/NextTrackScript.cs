using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class NextTrackScript : MonoBehaviour
{
    public PlayableDirector PlayableDirector;
    public GameObject Buttons;

    // Update is called once per frame
    void Update()
    {
        if (PlayableDirector.state != PlayState.Playing)
        {
            Buttons.SetActive(true);
        }
    }
}
