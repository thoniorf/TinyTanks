using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayState : GameManagerState
{
    public PlayState(GameManagerStateMachine stateMachine, GameManagerStateFactory stateFactory) : base(stateMachine, stateFactory)
    {
    }

    public override void enterState()
    {
        Debug.Log("Play");
        _gm.GameModeEventChannel.GameReady();
        loadScene();
        _gm.isPaused = false;
        _gm.GameModeEventChannel.GameStart();
    }

    protected abstract void loadScene();

    public override void exitState()
    {
        Debug.Log("Pausing");
    }

    public override void tryGetTransition()
    {
        throw new System.NotImplementedException();
    }

    public override void updateState()
    {
        if (_gm.isPaused)
        {
            transition(_stateFactory.GetPauseState(_stateMachine));
        }
    }
}
