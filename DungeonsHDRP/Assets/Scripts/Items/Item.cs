using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item : MonoBehaviour
{
    public string Name;
    public string Description;
    public Sprite ItemImage;
    public bool Equippable { get; protected set; }

    public Item GetPickedUp()
    {
        Destroy(gameObject);
        return this;
    }

    private void Start()
    {
        this.Equippable = false;
    }
}
