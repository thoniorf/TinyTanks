using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayModeState : PlayState
{
    public LocalPlayModeState(GameManagerStateMachine stateMachine, GameManagerStateFactory stateFactory) : base(stateMachine, stateFactory)
    {
    }

    protected override void loadScene()
    {
        _asyncSceneLoader.asyncLoadSample();
    }

}
