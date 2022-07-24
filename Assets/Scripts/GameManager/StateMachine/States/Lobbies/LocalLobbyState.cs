using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalLobbyState : LobbyState
{
    protected PlayerInputManager _playerInputManager;

    public LocalLobbyState(GameManagerStateMachine stateMachine, GameManagerStateFactory stateFactory) : base(stateMachine, stateFactory)
    {
    }

    public override void enterState()
    {
        base.enterState();
        _playerInputManager = PlayerInputManager.instance;
        //EnablePlayerInputEvents();

    }

    public override void exitState()
    {
        base.exitState();
        //DisablePlayerInputEvents();
    }

    public override void loadScene()
    {
        _asyncSceneLoader.asyncLoadLobby();
    }

    protected override void GameStart()
    {
        if (_gm.ActivePlayersList.Count == _gm.NumOfPlayer)
        {
            transition(_stateFactory.GetPlayState(_stateMachine));
        }
    }

    protected override void OnLocalPlayerJoined()
    {

        _lobbyEvents.JoinPlayer();
        Debug.Log("I wish to play");
        // instantiate the lobby player prefab
        // update the player active to list with control schema
        // we don't want double control schema
        // the list will be used be playstate to instantiate

        // _gm.AddPlayerToActiveList(player);
    }

    public override void tryGetTransition()
    {
        throw new System.NotImplementedException();
    }

    public override void updateState()
    {
        // nothing, but we don't want to raise exception
    }
}
