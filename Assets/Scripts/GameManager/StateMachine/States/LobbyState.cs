using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class LobbyState : GameManagerState
{


    // Events Channels
    protected LobbyEventChannel _lobbyEvents;

    public LobbyState(GameManagerStateMachine stateMachine, GameManagerStateFactory stateFactory) : base(stateMachine, stateFactory)
    {
    }

    public override void enterState()
    {
        Debug.Log("Entering Lobby");

        _lobbyEvents = _gm.LobbyEventChannel;
        EnableLobbyEvents();

        loadScene();
    }

    public abstract void loadScene();

    public override void exitState()
    {
        Debug.Log("Leaving lobby");
        DisableLobbyEvents();
    }

    public abstract override void tryGetTransition();

    public abstract override void updateState();

    private void EnableLobbyEvents()
    {
        _lobbyEvents.GameStartEvent += GameStart;
    }

    private void DisableLobbyEvents()
    {
        _lobbyEvents.GameStartEvent -= GameStart;
    }

    protected abstract void GameStart();
}
