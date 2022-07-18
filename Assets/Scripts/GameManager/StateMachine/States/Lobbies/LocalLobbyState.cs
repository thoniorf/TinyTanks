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
        EnablePlayerInputEvents();

    }

    public override void exitState()
    {
        base.exitState();
        DisablePlayerInputEvents();
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

    private void EnablePlayerInputEvents()
    {
        _playerInputManager.onPlayerJoined += OnLocalPlayerJoined;
        _playerInputManager.onPlayerLeft += OnLocalPlayerLeft;
    }

    private void DisablePlayerInputEvents()
    {
        _playerInputManager.onPlayerJoined -= OnLocalPlayerJoined;
        _playerInputManager.onPlayerLeft -= OnLocalPlayerLeft;
    }

    private void OnLocalPlayerJoined(PlayerInput obj)
    {
        Character player = obj.gameObject.GetComponent<Character>();
        Debug.Log("Player joined with " + obj.currentControlScheme);

        _gm.AddPlayerToActiveList(player);
    }

    private void OnLocalPlayerLeft(PlayerInput obj)
    {
        Debug.Log("Player with " + obj.currentControlScheme + " left");
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
