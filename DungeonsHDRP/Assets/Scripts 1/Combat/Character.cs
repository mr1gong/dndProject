using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Character : MonoBehaviour
{
    public int Strength;
    public int Dexterity;
    public int Constitution;
    public int Intelligence;
    public int Wisdom;
    public int Charisma;

    public int ArmourClass;
    public int Speed;
    public int HitPoints;
    public int Initiative;

    public enum Attribute
    {
        Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma
    }

    public int GetModifier(Attribute attribute)
    {
        switch (attribute)
        {
            case Attribute.Strength:
                return Modifier(Strength);
            case Attribute.Dexterity:
                return Modifier(Dexterity);
            case Attribute.Constitution:
                return Modifier(Constitution);
            case Attribute.Intelligence:
                return Modifier(Intelligence);
            case Attribute.Wisdom:
                return Modifier(Wisdom);
            case Attribute.Charisma:
                return Modifier(Charisma);
            default:
                throw new Exception("Invalid Input");
        }
        int Modifier(int attributeValue)
        {
            int modifierValue = (attributeValue - 10) / 2;
            return modifierValue;
        }
    }
}
