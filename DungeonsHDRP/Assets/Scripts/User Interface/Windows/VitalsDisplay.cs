using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitalsDisplay : UIElement
{
    public Slider HealthBar;
    public static int HitPoints = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value = HitPoints;
    }
}
