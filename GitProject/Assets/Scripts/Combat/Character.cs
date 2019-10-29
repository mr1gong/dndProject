/**
 * Author: Jindrich Novak
**/

using UnityEngine;
using System;

public abstract class Character : MonoBehaviour
{
    #region Fields
    public string Name;

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

    public enum Ability
    {
        Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma
    }
    #endregion

    //Calculates and returns the modifier value from the selected ability score
    public int GetModifier(Ability attribute)
    {
        return attribute switch
        {
            Ability.Strength     => Modifier(Strength),
            Ability.Dexterity    => Modifier(Dexterity),
            Ability.Constitution => Modifier(Constitution),
            Ability.Intelligence => Modifier(Intelligence),
            Ability.Wisdom       => Modifier(Wisdom),
            Ability.Charisma     => Modifier(Charisma),
            _ => throw new Exception("Invalid Input"),
        };

        int Modifier(int attributeValue)
        {
            int modifierValue = (attributeValue - 10) / 2;
            return modifierValue;
        }
    }

    public int MakeAbilityCheck(Ability attribute)
    {
        return Roller.d20() + GetModifier(attribute);
    }
}

#region Temporary
/*switch (attribute)
        {
            case Ability.Strength:
                return Modifier(Strength);

            case Ability.Dexterity:
                return Modifier(Dexterity);

            case Ability.Constitution:
                return Modifier(Constitution);

            case Ability.Intelligence:
                return Modifier(Intelligence);

            case Ability.Wisdom:
                return Modifier(Wisdom);

            case Ability.Charisma:
                return Modifier(Charisma);

            default:
                throw new Exception("Invalid Input");
        }
*/
#endregion