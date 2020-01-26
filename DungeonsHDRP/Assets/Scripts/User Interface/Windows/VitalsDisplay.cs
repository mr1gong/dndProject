using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitalsDisplay : UIElement
{
    public Slider HealthBar;

    public static VitalsDisplay instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetHitPoints(int hitPointsPercentage)
    {

        HealthBar.value = hitPointsPercentage;
    }
    public void SetDefaultHP(int defaultHP, bool updateHP)
    {
        /*
        HealthBar.maxValue = defaultHP;
        if (updateHP)
        {
            HealthBar.value = defaultHP;
        } 
        */
    }
    public static VitalsDisplay GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<VitalsDisplay>();
        }
        return instance;
    }

}
