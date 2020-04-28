using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Item : MonoBehaviour
{
    public string Name;
    public string Description;
    public Sprite ItemImage;
    public UnityEvent OnPickup;
    public bool Equippable { get; protected set; }

    public Item GetPickedUp()
    {
        OnPickup.Invoke();
        gameObject.SetActive(false);
        gameObject.transform.SetParent(Protagonist.GetPlayerInstance().transform);

        return this;
    }

    private void Start()
    {
        this.Equippable = false;
    }

    public void SetAsPickupTarget() 
    {
        Protagonist.GetPlayerInstance().SetTarget(this);
    }

}

