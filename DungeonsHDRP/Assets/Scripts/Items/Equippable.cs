using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Equippable : Item
{
   public enum EquippableType
    {
        Weapon,
        Head,
        Torso,
        Legs,
        Feet,
        Hands
    }

    public EquippableType Type = EquippableType.Weapon;
    public ModifierCollection ModifierCollection { get; set; }

    public void SetModifiers(ModifierCollection modifierCollection)
    {
        this.ModifierCollection = modifierCollection;
    }

}