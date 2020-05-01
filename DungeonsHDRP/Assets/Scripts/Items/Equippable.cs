using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class ModifierPair 
{
    public ModifierNames modifier;
    public int modifierValue;
}
public class Equippable : Item
{
   public enum EquippableType
    {
        Weapon,
        Head,
        Torso,
        Legs,
        Feet,
        Hands,
        Misc

    }

    private void Start()
    {
        this.Equippable = true;
        if(ModifierCollection == null) 
        {
            ModifierCollection = new ModifierCollection();
           
        }
        foreach (var v in modifierPairs)
        {

            ModifierCollection.Modifiers.Add(v.modifier, v.modifierValue);
        }

    }

    public List<ModifierPair> modifierPairs;
    public EquippableType Type = EquippableType.Weapon;
    public GameObject model;
    public ModifierCollection ModifierCollection { get; set; }

    public void SetModifiers(ModifierCollection modifierCollection)
    {
        this.ModifierCollection = modifierCollection;
    }


}