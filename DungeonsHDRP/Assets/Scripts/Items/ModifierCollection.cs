using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModifierNames
{
    Damage,
    ArmorClass
}
public class ModifierCollection : MonoBehaviour
{
    public Dictionary<string, int> Modifiers { get; set; }


}
