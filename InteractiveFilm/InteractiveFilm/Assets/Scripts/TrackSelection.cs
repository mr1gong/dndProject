using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TrackSelection : MonoBehaviour
{
    public PlayableDirector Timeline;
    public GameObject Buttons;

    public void PlayTimeline()
    {
        Timeline.Play();
        Buttons.SetActive(false);
    }
}
