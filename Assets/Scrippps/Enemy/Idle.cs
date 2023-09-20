using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public bool canSeePlayer;
    public Chase chaseState;

    public override State RunCurrentState()
    {
        if (canSeePlayer)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }
}
