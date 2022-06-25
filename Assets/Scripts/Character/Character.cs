using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public event UnityAction AttackEvent = delegate { };

    [Header("Public info")]
    [Space]
    public Vector3 movementVector;
    public Vector3 lookVector;
    public int speed { get { return _speed; } set { _speed = value; } }
    public int hitPoints { get { return _hitPoints; } set { _hitPoints = value; } }

    public bool isColliding;
    public bool isTriggered;

    [Header("References")]
    [Space]
    [SerializeField] private InputReader _inputReader = default;
    [SerializeField] private CharacterStats _statsSO = default;
    [SerializeField] Transform _turret;

    [Header("Input values")]
    [Space]
    [SerializeField] private Vector2 _movementInputVector;
    [SerializeField] private Vector2 _lookInputVector;

    [Header("Character stats")]
    [Space]
    [SerializeField] private int _speed = 10;
    [SerializeField] private int _hitPoints = 3;


    private void OnEnable()
    {
        _inputReader.MoveEvent += Move;
        _inputReader.LookEvent += Look;
        _inputReader.AttackEvent += Attack;
    }

    private void OnDisable()
    {
        _inputReader.MoveEvent -= Move;
        _inputReader.LookEvent -= Look;
        _inputReader.AttackEvent -= Attack;
    }

    private void Start()
    {
        PropagateStatsFromSO();
    }

    private void PropagateStatsFromSO()
    {
        if (_statsSO != null)
        {
            _speed = _statsSO.Speed;
            _hitPoints = _statsSO.HitPoints;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        RotateTurret();
    }

    private void FixedUpdate()
    {
        CalculateAim();

    }

    private void RotateTurret()
    {
        if (_turret != null)
        {
            _turret.LookAt(lookVector);
        }
    }

    private void CalculateAim()
    {
        const float cannonOffset = 0.6f;

        Vector3 look = new Vector3(_lookInputVector.x, _lookInputVector.y, 0f);
        Ray ray = Camera.main.ScreenPointToRay(look);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
        {
            lookVector = new Vector3(hit.point.x, cannonOffset, hit.point.z);
        }
    }

    private void CalculateMovement()
    {
        Vector3 movement = new Vector3(_movementInputVector.x, 0f, _movementInputVector.y);
        movementVector = movement;
    }

    private void Move(Vector2 movement)
    {
        _movementInputVector = movement;
    }

    private void Look(Vector2 look)
    {
        _lookInputVector = look;
    }

    private void Attack()
    {
        AttackEvent.Invoke();
    }

    private void OnCollisionEnter(Collision other)
    {

    }

    private void OnCollisionExit(Collision other)
    {
        isColliding = false;
    }

}
