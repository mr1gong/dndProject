using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModifierNames
{
    Damage,
    ArmorClass
}
public class ModifierCollection
{
    public Dictionary<ModifierNames, int> Modifiers { get; set; }

    public ModifierCollection() 
    {
        Modifiers = new Dictionary<ModifierNames, int>();
    }
}
