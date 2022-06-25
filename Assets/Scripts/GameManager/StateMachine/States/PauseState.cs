using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : GameManagerState
{
    public PauseState(GameManagerStateMachine stateMachine, GameManagerStateFactory stateFactory) : base(stateMachine, stateFactory)
    {
    }

    public override void enterState()
    {
        Time.timeScale = 0;
    }

    public override void exitState()
    {
        Time.timeScale = 1;
    }

    public override void tryGetTransition()
    {
        throw new System.NotImplementedException();
    }

    public override void updateState()
    {
        if (!_gm.isPaused)
        {
            transition(_stateFactory.GetPlayState(_stateMachine));
        }
    }

}
