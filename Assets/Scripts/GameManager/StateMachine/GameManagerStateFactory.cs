using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerStateFactory : IStateFactory
{
    public PlayState GetPlayState(GameManagerStateMachine _gmStateMachine)
    {
        return new LocalPlayModeState(_gmStateMachine, this);
    }

    public PauseState GetPauseState(GameManagerStateMachine _gmStateMachine)
    {
        return new PauseState(_gmStateMachine, this);
    }

    public MainMenuState GetMainMenuState(GameManagerStateMachine _gmStateMachine)
    {
        return new MainMenuState(_gmStateMachine, this);
    }

    public LobbyState GetLocalLobbyState(GameManagerStateMachine _gmStateMachine)
    {
        return new LocalLobbyState(_gmStateMachine, this);
    }
}
