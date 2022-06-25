using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerStateMachine : StateMachine
{
    public override State CurrentState { get { return _gmState; } set { _gmState = (GameManagerState)value; } }

    private GameManagerState _gmState;
    private GameManagerStateFactory _gmStateFactory;

    private void OnEnable()
    {
        if (_gmStateFactory == null)
        {
            _gmStateFactory = new GameManagerStateFactory();
        }

    }

    void Start()
    {
        _gmState = _gmStateFactory.GetMainMenuState(this);
        _gmState.enterState();
    }

    // Update is called once per frame
    void Update()
    {
        _gmState.updateState();
    }
}
