using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public string Name;
    public string Description;

    private readonly string hit;
    private readonly string damage;

    public int Hit()
    {
        if (hit == null) return 0;
        //  return Character.Roll(hit);
        return 0;
    }

    public int Damage()
    {
        if (damage == null) return 0;
        //return Character.Roll(damage);
        return 0;
    }
}
