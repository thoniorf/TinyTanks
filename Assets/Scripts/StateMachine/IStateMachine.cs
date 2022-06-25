using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateMachine
{
    public State CurrentState { get; set; }

}
