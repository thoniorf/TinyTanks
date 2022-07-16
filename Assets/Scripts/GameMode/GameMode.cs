using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameType
{
    SinglePayer, Local, Online
}

public abstract class GameMode
{
    public GameType GameType { get; protected set; }

    public GameMode() { }

    public abstract void Enable();
    public abstract void Disable();
    public abstract void Start();
    public abstract void GameOver();
}
