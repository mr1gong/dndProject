using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combatant : Character
{
    public Attack WeaponAttack;
    public float coolDownState = 0f;
    //Temporary cooldown value
    private float cooldownValue = 4.0f;
    protected override void Update()
    {
        base.Update();
        if (coolDownState >= 0) coolDownState -= Time.deltaTime;
    }

    public bool Attack(Character target)
    {
        coolDownState = cooldownValue;
        int attackRoll = Roller.d20() + GetModifier(Ability.Strength);

        if (target.ArmourClass < attackRoll)
        {
            int damage = Roller.MakeRoll("3d7") + 10;//WeaponAttack.DamageFormulaOffset;
            target.ReceiveDamange(damage);
            return true;
        }
        return false;
    }
}