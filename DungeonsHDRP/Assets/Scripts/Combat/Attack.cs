using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //Example: 3d7
    public string AttackFormula;
    //Example: +3 (so the complete attack calculation is 3d7 + 3
    public int AttackFormulaOffset;
    //Example: 30 feet
    public int Range;
    //Example: Flail
    public AttackType AttackType;
}
