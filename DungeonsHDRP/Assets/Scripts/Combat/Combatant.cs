using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combatant : Character
{
    public Attack WeaponAttack;

    public float coolDownState = 0f;
    //Temporary cooldown value
    public float cooldownValue = 4.0f;

    protected override void Update()
    {
        base.Update();
        if (coolDownState >= 0) coolDownState -= Time.deltaTime;
    }

    public int Attack(Interactible target, string damageFormula = "3d7")
    {
        int dmgModifier = 0;
        if (Inventory != null)
        {
            if (Inventory.equipped != null)
            {
                if(Inventory.equipped.ModifierCollection.Modifiers.ContainsKey(ModifierNames.Damage))
                dmgModifier = Inventory.equipped.ModifierCollection.Modifiers[ModifierNames.Damage];
                Debug.Log(dmgModifier);
            }
        }

        coolDownState = cooldownValue;
        int attackRoll = Roller.d20() + GetModifier(Ability.Strength);

        if (target.ArmourClass < attackRoll)
        {
            
            int damage = Roller.MakeRoll(damageFormula)+dmgModifier;//WeaponAttack.DamageFormulaOffset;
            Debug.Log(damage);
            target.ReceiveDamange(damage);
        }

        return attackRoll;
    }
}