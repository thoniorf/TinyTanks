using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : CharacterState
{
    protected Rigidbody _characterRigidBody;
    public MoveState(CharacterStateMachine stateMachine, CharacterStateFactory stateFactory) : base(stateMachine, stateFactory)
    {
    }

    public override void enterState()
    {
        // Debug.Log("Enter Move state");
        _characterRigidBody = _stateMachine.GetComponent<Rigidbody>();
    }

    public override void exitState()
    {
        // Debug.Log("Exit Move state");
    }

    public override void tryGetTransition()
    {
        throw new System.NotImplementedException();
    }

    public override void updateState()
    {
        _characterRigidBody.velocity = _character.movementVector;

        if (_characterRigidBody.velocity == Vector3.zero)
        {
            transition(_stateFactory.GetIdleState(_stateMachine));
        }


    }
}
