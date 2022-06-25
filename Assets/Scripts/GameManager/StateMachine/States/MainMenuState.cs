using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : GameManagerState
{
    public MainMenuState(GameManagerStateMachine stateMachine, GameManagerStateFactory stateFactory) : base(stateMachine, stateFactory)
    {
    }

    public override void enterState()
    {
        Debug.Log("Main menu");
        transition(_stateFactory.GetLobbyState(_stateMachine));
    }

    public override void exitState()
    {
        Debug.Log("Moving to lobby");
    }

    public override void tryGetTransition()
    {
        throw new System.NotImplementedException();
    }

    public override void updateState()
    {
        // nothing, just ui
    }

}
