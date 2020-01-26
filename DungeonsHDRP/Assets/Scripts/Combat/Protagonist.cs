using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonist : Combatant
{
    private bool init = false;
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
        //VitalsDisplay.HitPoints = this.HitPoints;
        //if (!init) { VitalsDisplay.GetInstance().SetDefaultHP(this.HitPoints,true); init = true; }
    }
    public override void ReceiveDamange(int damageSustained)
    {
        base.ReceiveDamange(damageSustained);
        VitalsDisplay.GetInstance().SetHitPoints(this.HitPoints*100/this.HitPoitMaximum);
    }

    
}