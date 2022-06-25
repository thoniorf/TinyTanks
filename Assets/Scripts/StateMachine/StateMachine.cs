using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour, IStateMachine
{
    public abstract State CurrentState { get; set; }
}
