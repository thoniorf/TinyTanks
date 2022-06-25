using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameModeEventChannel", menuName = "Events/Game Mode Event Channel")]
public class GameModeEventChannel : ScriptableObject
{
    public event UnityAction PlayerScoreEvent = delegate { };

    public void PlayerScore()
    {
        PlayerScoreEvent.Invoke();
    }
}
