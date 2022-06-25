using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputManager))]
public class GameManager : MonoBehaviour
{

    public bool isPaused;
    [field: SerializeField]
    private bool DestroyOnLoad { get; set; }

    [Header("References")]
    [Space]
    [SerializeField] private InputReader _inputReader = default;
    private PlayerInputManager _playerInputManager;

    [Header("Event channels")]
    [Space]
    [SerializeField] private GameModeEventChannel _gameModeEventChannel = default;

    private void OnEnable()
    {
        if (!DestroyOnLoad)
            DontDestroyOnLoad(gameObject);

        _playerInputManager = GetComponent<PlayerInputManager>();
        // events
        enablePlayerInputEvents();
        _inputReader.PauseEvent += Pause;
        _gameModeEventChannel.PlayerScoreEvent += PlayerScore;
    }

    private void OnDisable()
    {
        // events
        disablePlayerInputEvents();
        _inputReader.PauseEvent -= Pause;
    }

    private void enablePlayerInputEvents()
    {
        _playerInputManager.onPlayerJoined += onLocalPlayerJoined;
        _playerInputManager.onPlayerLeft += onLocalPlayerLeft;
    }

    private void disablePlayerInputEvents()
    {
        _playerInputManager.onPlayerJoined -= onLocalPlayerJoined;
        _playerInputManager.onPlayerLeft -= onLocalPlayerLeft;
    }

    private void onLocalPlayerJoined(PlayerInput obj)
    {
        Debug.Log("Player joined with " + obj.currentControlScheme);
    }

    private void onLocalPlayerLeft(PlayerInput obj)
    {
        throw new NotImplementedException();
    }

    private void PlayerScore()
    {
        Debug.Log("Player Scored");
    }

    private void Pause()
    {
        isPaused = !isPaused;
    }
}
