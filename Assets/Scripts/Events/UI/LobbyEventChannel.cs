using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "LobbyEventChannel", menuName = "Events/UI/Lobby Event Channel")]
public class LobbyEventChannel : ScriptableObject
{
    public event UnityAction GameStartEvent = delegate { };


    public void StartGame()
    {
        GameStartEvent.Invoke();
    }


}
