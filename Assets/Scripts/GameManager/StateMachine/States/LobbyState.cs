using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyState : GameManagerState
{
    public LobbyState(GameManagerStateMachine stateMachine, GameManagerStateFactory stateFactory) : base(stateMachine, stateFactory)
    {
    }

    public override void enterState()
    {
        Debug.Log("Lobby");
        AsyncSceneLoader asyncSceneLoader = _gm.GetComponent<AsyncSceneLoader>();
        asyncSceneLoader.asyncLoadLobby();
        transition(_stateFactory.GetPlayState(_stateMachine));
    }

    public override void exitState()
    {
        Debug.Log("Starting game");
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
