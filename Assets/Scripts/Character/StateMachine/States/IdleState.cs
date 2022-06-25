using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CharacterState
{
    public IdleState(CharacterStateMachine stateMachine, CharacterStateFactory stateFactory) : base(stateMachine, stateFactory)
    {
    }

    public override void enterState()
    {
        // Debug.Log("Enter Idle state");
    }

    public override void exitState()
    {
        // Debug.Log("Exit Idle state");
    }

    public override void tryGetTransition()
    {
        throw new System.NotImplementedException();
    }

    public override void updateState()
    {
        if (_character.movementVector != Vector3.zero)
        {
            transition(_stateFactory.GetMoveState(_stateMachine));
        }

        if (_character.hitPoints == 0)
        {
            transition(_stateFactory.GetDestroyedState(_stateMachine));
        }
    }
}
