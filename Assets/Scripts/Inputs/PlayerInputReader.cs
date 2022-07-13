using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputReader : MonoBehaviour
{

    public event UnityAction<Vector2> MoveEvent = delegate { };
    public event UnityAction<Vector2> LookEvent = delegate { };
    public event UnityAction AttackEvent = delegate { };

    public event UnityAction PauseEvent = delegate { };

    public void OnMove(InputValue value)
    {
        MoveEvent.Invoke(value.Get<Vector2>());
    }

    public void OnAttack(InputValue value)
    {
        AttackEvent.Invoke();
    }

    public void OnLook(InputValue value)
    {
        LookEvent.Invoke(value.Get<Vector2>());
    }

    public void OnPause(InputValue value)
    {
        PauseEvent.Invoke();
    }
}
