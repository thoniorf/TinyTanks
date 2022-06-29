using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameMode
{
    private GameMatch _gameMatch;

    public GameMode()
    {

    }

    public abstract void Enable();
    public abstract void Disable();

    public void SetGameMatchFreeForAll()
    {
        _gameMatch = new FreeForAll();
    }
}
