using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public State currentState;

    private void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        //when the enemy finds player, they must switch to the next state, which is attack.
        State nextState = currentState?.RunCurrentState();

        if (nextState != null)
        {
            SwitchToNextState(nextState);
        }

    }

    private void SwitchToNextState(State nextState)
    {
        //change the enemy current state to suit whatever action they need to take
        currentState = nextState;
    }
}
