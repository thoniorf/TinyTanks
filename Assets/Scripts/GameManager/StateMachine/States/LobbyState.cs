using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LobbyState : GameManagerState
{
    private PlayerInputManager _playerInputManager;

    // Events Channels
    private LobbyEventChannel _lobbyEvents;

    public LobbyState(GameManagerStateMachine stateMachine, GameManagerStateFactory stateFactory) : base(stateMachine, stateFactory)
    {
    }

    public override void enterState()
    {
        Debug.Log("Lobby");

        AsyncSceneLoader asyncSceneLoader = _gm.GetComponent<AsyncSceneLoader>();
        asyncSceneLoader.asyncLoadLobby();

        _playerInputManager = PlayerInputManager.instance;
        EnablePlayerInputEvents();

        _lobbyEvents = _gm.LobbyEventChannel;
        EnableLobbyEvents();

        _gm.SetGameModeLocalMultiplayer();
    }

    public override void exitState()
    {
        DisablePlayerInputEvents();
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

    private void EnableLobbyEvents()
    {
        _lobbyEvents.GameStartEvent += GameStart;
    }

    private void DisableLobbyEvents()
    {
        _lobbyEvents.GameStartEvent -= GameStart;
    }

    private void GameStart()
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

}
