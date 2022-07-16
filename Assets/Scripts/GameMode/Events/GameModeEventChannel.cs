using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameModeEventChannel", menuName = "Events/Game Mode Event Channel")]
public class GameModeEventChannel : ScriptableObject
{
    public event UnityAction PlayerScoreEvent = delegate { };
    public event UnityAction PlayerHitEvent = delegate { };
    public event UnityAction GameReadyEvent = delegate { };
    public event UnityAction GameStartEvent = delegate { };
    public event UnityAction GameOverEvent = delegate { };

    // TODO which player?
    public void PlayerScore()
    {
        PlayerScoreEvent.Invoke();
    }

    // TODO which player?
    public void PlayerHit()
    {
        PlayerHitEvent.Invoke();
    }

    public void GameReady()
    {
        GameReadyEvent.Invoke();
    }

    public void GameStart()
    {
        GameStartEvent.Invoke();
    }

    public void GameOver()
    {
        GameOverEvent.Invoke();
    }
}
