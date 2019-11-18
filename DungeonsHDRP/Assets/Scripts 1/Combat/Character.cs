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

    public int ArmourClass;
    public int Speed;
    public int HitPoints;
    public int Initiative;

    public enum Ability
    {
        Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma
    }
    #endregion
    
    /*
    protected virtual void Update()
    {
        if (HitPoints <= 0) this.InitiateDeathSequence();
    }
    */

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

    //This method is called whenever the character sustains damage
    public void ReceiveDamange(int damageSustained)
    {
        if(HitPoints - damageSustained >= 0)
        {
            HitPoints -= damageSustained;
        }

        else
        {
            HitPoints = 0;
        }

        if (HitPoints <= 0)
        {
            InitiateDeathSequence();
        }
    }

    //The following code is run when the character dies
    protected virtual void InitiateDeathSequence()
    {


    }
}

