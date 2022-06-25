using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameManagerState : State
{
    protected GameManager _gm;

    protected new GameManagerStateFactory _stateFactory;
    protected new GameManagerStateMachine _stateMachine;

    public GameManagerState(GameManagerStateMachine stateMachine, GameManagerStateFactory stateFactory) : base(stateMachine, stateFactory)
    {
        _gm = stateMachine.GetComponent<GameManager>();
        _stateMachine = stateMachine;
        _stateFactory = stateFactory;
    }
}
