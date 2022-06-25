using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class CharacterState : State
{
    protected Character _character;

    protected new CharacterStateFactory _stateFactory;
    protected new CharacterStateMachine _stateMachine;

    protected CharacterState(CharacterStateMachine stateMachine, CharacterStateFactory stateFactory) : base(stateMachine, stateFactory)
    {
        _character = stateMachine.GetComponent<Character>();
        _stateMachine = stateMachine;
        _stateFactory = stateFactory;
    }

    public void OnCollisionEnter(Collision other)
    {
        _character.isColliding = true;
        if (other.gameObject.tag == "Bullet")
        {
            _character.hitPoints -= 1;
        }

        if (_character.hitPoints == 0)
        {
            _stateMachine.GameModeEventChannel.PlayerScore();
        }

    }
}
