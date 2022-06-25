using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : GameManagerState
{
    public PlayState(GameManagerStateMachine stateMachine, GameManagerStateFactory stateFactory) : base(stateMachine, stateFactory)
    {
    }

    public override void enterState()
    {
        Debug.Log("Play");
        AsyncSceneLoader asyncSceneLoader = _gm.GetComponent<AsyncSceneLoader>();
        asyncSceneLoader.asyncLoadSample();
        _gm.isPaused = false;
    }

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
