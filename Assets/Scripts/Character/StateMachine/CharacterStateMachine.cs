using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMachine : StateMachine
{
    public override State CurrentState { get { return _currentState; } set { _currentState = (CharacterState)value; } }

    [Header("Event channels")]
    [Space]
    public GameModeEventChannel GameModeEventChannel = default;


    private CharacterState _currentState;
    private CharacterStateFactory _stateFactory;

    private void OnEnable()
    {
        if (_stateFactory == null)
        {
            _stateFactory = new CharacterStateFactory();
        }
    }

    void Start()
    {
        _currentState = _stateFactory.GetIdleState(this);
        _currentState.enterState();
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.updateState();
    }

    private void OnCollisionEnter(Collision other)
    {
        _currentState.OnCollisionEnter(other);
    }
}
