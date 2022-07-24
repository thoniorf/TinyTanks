using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class LobbyState : GameManagerState, GameInputs.IJoinActions
{


    // Events Channels
    protected LobbyEventChannel _lobbyEvents;

    // Input to join
    private GameInputs _gameInputs;

    public LobbyState(GameManagerStateMachine stateMachine, GameManagerStateFactory stateFactory) : base(stateMachine, stateFactory)
    {
        _gameInputs = new GameInputs();

        // we care about Join actions maps only
        _gameInputs.Join.SetCallbacks(this);
        _gameInputs.Join.Enable();
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

    public void OnJoin(InputAction.CallbackContext context)
    {


        if (context.phase == InputActionPhase.Performed)
        {
            string outputString = "";
            InputDevice inputDevice = context.control.device;

            outputString += inputDevice.displayName + " supported in ";
            foreach (InputControlScheme _controlScheme in _gameInputs.controlSchemes)
            {
                if (_controlScheme.SupportsDevice(inputDevice))
                {
                    outputString += _controlScheme.name + " ";
                }

            }

            Debug.Log(outputString);
            OnLocalPlayerJoined();
        }
    }

    protected abstract void OnLocalPlayerJoined();
}
