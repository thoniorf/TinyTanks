using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputManager))]
public class GameManager : MonoBehaviour
{

    public bool isPaused;
    public List<Character> ActivePlayersList { get; private set; }
    public int NumOfPlayer = 2;
    [field: SerializeField] private bool DestroyOnLoad { get; set; }


    [Header("References")]
    [Space]
    private PlayerInputManager _playerInputManager;
    private GameMode _gameMode;


    [Header("Event channels")]
    [Space]
    // Main menu event channel
    public LobbyEventChannel LobbyEventChannel = default;
    public GameModeEventChannel GameModeEventChannel = default;


    private void OnEnable()
    {
        if (!DestroyOnLoad)
            DontDestroyOnLoad(gameObject);

        // _playerInputManager = PlayerInputManager.Instantiate();

        GameModeEventChannel.PlayerScoreEvent += PlayerScore;
    }

    private void OnDisable()
    {
        if (_gameMode != null) _gameMode.Disable();

        GameModeEventChannel.PlayerScoreEvent -= PlayerScore;
    }

    private void PlayerScore()
    {
        Debug.Log("Player Scored");
    }

    public void SetGameModeLocalMultiplayer()
    {
        if (_gameMode != null) _gameMode.Disable();
        _gameMode = new LocalMultiplayer(PlayerInputManager.instance);
    }

    public void AddPlayerToActiveList(Character player)
    {
        if (ActivePlayersList == null)
        {
            ActivePlayersList = new List<Character>();
        }

        ActivePlayersList.Add(player);
    }
}
