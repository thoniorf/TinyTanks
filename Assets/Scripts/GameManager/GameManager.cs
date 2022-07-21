using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputManager))]
public class GameManager : MonoBehaviour
{
    public bool isPaused;

    public List<Character> ActivePlayersList { get => _activePlayerList; private set => _activePlayerList = value; }
    public int NumOfPlayer = 2;

    [field: SerializeField] private bool DestroyOnLoad { get; set; }
    private List<Character> _activePlayerList;


    [Header("References")]
    [Space]
    private PlayerInputManager _playerInputManager;

    [Header("Event channels")]
    [Space]
    public MainMenuEventChannel MainMenuEventChannel = default;
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
        GameModeEventChannel.PlayerScoreEvent -= PlayerScore;
    }

    private void PlayerScore()
    {
        Debug.Log("Player Scored");
    }

    public void AddPlayerToActiveList(Character player)
    {

        if (_activePlayerList == null)
        {
            _activePlayerList = new List<Character>();
        }

        _activePlayerList.Add(player);
    }
}
