using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonist : Combatant
{
    protected override void InitiateDeathSequence()
    {
        UIController.GetInstance().SwitchWindow("DeathSequence");
        //_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        PlayerMovement.MovementEnabled = false;
    }
}
