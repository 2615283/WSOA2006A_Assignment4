using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : State
{
    public bool withinAttackRange;
    public Attack attackState;
    public override State RunCurrentState()
    {
        if (withinAttackRange)
        {
            return attackState;
        }
        else
        {
            return this;
        }
    }
}
