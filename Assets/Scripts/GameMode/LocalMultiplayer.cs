using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiplayer : GameMode
{
    private PlayerInputManager _playerInputManager;
    public LocalMultiplayer(PlayerInputManager playerInputManager) : base()
    {
        this._playerInputManager = playerInputManager;
        GameType = GameType.Local;
    }

    public override void Enable()
    {
        EnablePlayerInputEvents();
    }

    public override void Disable()
    {
        DisablePlayerInputEvents();
    }

    private void EnablePlayerInputEvents()
    {
        _playerInputManager.onPlayerJoined += OnLocalPlayerJoined;
        _playerInputManager.onPlayerLeft += OnLocalPlayerLeft;
    }

    private void DisablePlayerInputEvents()
    {
        _playerInputManager.onPlayerJoined -= OnLocalPlayerJoined;
        _playerInputManager.onPlayerLeft -= OnLocalPlayerLeft;
    }

    private void OnLocalPlayerJoined(PlayerInput obj)
    {
        Debug.Log("Player joined with " + obj.currentControlScheme);
    }

    private void OnLocalPlayerLeft(PlayerInput obj)
    {
        Debug.Log("Player with " + obj.currentControlScheme + " left");
    }

    public override void Start()
    {
        throw new NotImplementedException();
    }

    public override void GameOver()
    {
        throw new NotImplementedException();
    }


}
