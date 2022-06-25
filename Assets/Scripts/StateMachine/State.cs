using System;

[Serializable]
public abstract class State
{
    protected IStateMachine _stateMachine;
    protected IStateFactory _stateFactory;

    public State(IStateMachine stateMachine, IStateFactory stateFactory)
    {
        _stateMachine = stateMachine;
        _stateFactory = stateFactory;
    }

    public abstract void enterState();
    public abstract void exitState();
    public abstract void updateState();
    public abstract void tryGetTransition();
    protected void transition(State nextState)
    {
        exitState();
        _stateMachine.CurrentState = nextState;
        nextState.enterState();

    }

    public string getStateName()
    {
        return this.GetType().Name;
    }
}
