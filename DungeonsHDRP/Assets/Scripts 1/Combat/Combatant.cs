using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combatant : Character
{
    public List<Attack> Attacks;

    protected override void Update()
    {
        base.Update();
    }
}
