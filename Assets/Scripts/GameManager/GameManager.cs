using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputManager))]
public class GameManager : MonoBehaviour
{

    public bool isPaused;
    [field: SerializeField] private bool DestroyOnLoad { get; set; }

    [Header("References")]
    [Space]
    [SerializeField] private InputReader _inputReader = default;
    private PlayerInputManager _playerInputManager;
    private GameMode _gameMode;


    [Header("Event channels")]
    [Space]
    [SerializeField] private GameModeEventChannel _gameModeEventChannel = default;

    private void OnEnable()
    {
        if (!DestroyOnLoad)
            DontDestroyOnLoad(gameObject);

        _playerInputManager = GetComponent<PlayerInputManager>();

        // events
        _inputReader.PauseEvent += Pause;
        _gameModeEventChannel.PlayerScoreEvent += PlayerScore;
    }

    private void OnDisable()
    {
        if (_gameMode != null) _gameMode.Disable();
        // events
        _inputReader.PauseEvent -= Pause;
        _gameModeEventChannel.PlayerScoreEvent -= PlayerScore;
    }

    private void PlayerScore()
    {
        Debug.Log("Player Scored");
    }

    private void Pause()
    {
        isPaused = !isPaused;
    }

    public void SetGameModeLocalMultiplayer()
    {
        if (_gameMode != null) _gameMode.Disable();
        _gameMode = new LocalMultiplayer(_playerInputManager);
        _gameMode.Enable();
    }
}
