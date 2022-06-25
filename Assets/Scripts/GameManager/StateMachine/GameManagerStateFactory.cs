using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerStateFactory : IStateFactory
{
    public PlayState GetPlayState(GameManagerStateMachine _gmStateMachine)
    {
        return new PlayState(_gmStateMachine, this);
    }

    public PauseState GetPauseState(GameManagerStateMachine _gmStateMachine)
    {
        return new PauseState(_gmStateMachine, this);
    }

    public MainMenuState GetMainMenuState(GameManagerStateMachine _gmStateMachine)
    {
        return new MainMenuState(_gmStateMachine, this);
    }

    public LobbyState GetLobbyState(GameManagerStateMachine _gmStateMachine)
    {
        return new LobbyState(_gmStateMachine, this);
    }
}
