using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalLobbyUIManager : MonoBehaviour
{

    [SerializeField] private LobbyEventChannel _lobbyEvents;

    private void OnEnable()
    {
        _lobbyEvents.PlayerJoinEvent += JoinPlayer;
    }

    private void OnDisable()
    {
        _lobbyEvents.PlayerJoinEvent += JoinPlayer;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void JoinPlayer()
    {
        Debug.Log("Spawn the player lobby prefab");
    }
}
