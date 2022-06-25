using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateFactory : IStateFactory
{

    public CharacterState GetIdleState(CharacterStateMachine stateMachine)
    {
        return new IdleState(stateMachine, this);
    }

    public CharacterState GetMoveState(CharacterStateMachine stateMachine)
    {
        return new MoveState(stateMachine, this);
    }

    internal State GetDestroyedState(CharacterStateMachine stateMachine)
    {
        return new DestroyedState(stateMachine, this);
    }
}
