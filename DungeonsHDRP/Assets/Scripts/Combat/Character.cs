/**
 * <Author>Jindrich Novak</Author>
**/

using System;

public abstract class Character : Interactible
{
    #region Fields
    public string Name;

    public int Strength;
    public int Dexterity;
    public int Constitution;
    public int Intelligence;
    public int Wisdom;
    public int Charisma;
    public float ViewAngle = 120.0f;
    //public int AttackRate = 1;

    //HitPoints & Armour Class are inherited from the Interactible Class.
    public int Speed;
    public int Initiative;

    public Interactible Target;

    public enum Ability
    {
        Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma
    }
    #endregion
    
    //BAD CODE: CHARACTER IS BEING BEING KILLED IN EVERY FRAME!
    protected virtual void Update()
    {
        base.UIUpdate();
    }

    //Calculates and returns the modifier value from the selected ability score
    public int GetModifier(Ability attribute)
    {
        switch (attribute)
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

