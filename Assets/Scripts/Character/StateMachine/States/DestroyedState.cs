using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedState : CharacterState
{
    public DestroyedState(CharacterStateMachine stateMachine, CharacterStateFactory stateFactory) : base(stateMachine, stateFactory)
    {
    }

    public override void enterState()
    {
        Debug.Log("Player destroyed");
        Character.Destroy(_character.gameObject);
    }

    public override void exitState()
    {
        throw new System.NotImplementedException();
    }

    public override void tryGetTransition()
    {
        throw new System.NotImplementedException();
    }

    public override void updateState()
    {
        // nothing, character is destroyed
    }

    public new void OnCollisionEnter(Collision other)
    {
        // nothing, character is destroyed
    }
}
