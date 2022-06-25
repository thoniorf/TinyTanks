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

    [Header("Event channels")]
    [Space]
    [SerializeField] private GameModeEventChannel _gameModeEventChannel = default;

    private void OnEnable()
    {
        if (!DestroyOnLoad)
            DontDestroyOnLoad(gameObject);

        _inputReader.PauseEvent += Pause;

        _gameModeEventChannel.PlayerScoreEvent += PlayerScore;
    }

    private void OnDisable()
    {
        _inputReader.PauseEvent -= Pause;
    }

    private void Pause()
    {
        isPaused = !isPaused;
    }

    private void PlayerScore()
    {
        Debug.Log("Player Scored");
    }



}
