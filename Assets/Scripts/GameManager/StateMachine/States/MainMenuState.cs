using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : GameManagerState
{

    // Events Channels
    private MainMenuEventChannel _mainMenuEvents;
    public MainMenuState(GameManagerStateMachine stateMachine, GameManagerStateFactory stateFactory) : base(stateMachine, stateFactory)
    {
    }

    public override void enterState()
    {
        Debug.Log("Main menu");
        _mainMenuEvents = _gm.MainMenuEventChannel;
        EnableMainMenuEvents();
    }


    public override void exitState()
    {
        DisableMainMenuEvents();
        Debug.Log("Moving to lobby");
    }

    private void EnableMainMenuEvents()
    {
        _mainMenuEvents.LocalGameModeEvent += SelectsLocalGameMode;
    }

    private void DisableMainMenuEvents()
    {
        _mainMenuEvents.LocalGameModeEvent -= SelectsLocalGameMode;
    }

    private void SelectsLocalGameMode()
    {
        transition(_stateFactory.GetLocalLobbyState(_stateMachine));
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
