using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonist : Combatant
{
    public void MakeInvincible(bool input)
    {
        _IsInvincible = input;
    }

    public void MakeInvincible()
    {
        _IsInvincible = true;
    }

    protected override void InitiateDeathSequence()
    {
        UIController.GetInstance().SwitchWindow(UIController.WindowNameResource.DeathSequence);
        //_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        PlayerMovement.MovementEnabled = false;
    }

    protected override void Update()
    {
        base.Update();
        VitalsDisplay.HitPoints = this.HitPoints;
    }
}
