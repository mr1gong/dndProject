using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Equippable : Item
{
   public enum EquippableType
    {
        Weapon,
        BreastPlate,
        Helmet,
        Boots,
        Shirt,
        Gloves,
        Pants
    }

    public EquippableType Type = EquippableType.Weapon;

}