using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonist : Combatant
{
    protected override void InitiateDeathSequence()
    {
        Time.timeScale = 0;
    }
}
