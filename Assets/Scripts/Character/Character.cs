using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInputReader))]
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
    [SerializeField] private CharacterStats _statsSO = default;
    [SerializeField] private PlayerInputReader _inputReader;
    [SerializeField] Transform _turret;
    [SerializeField] Transform _aim;

    [Header("Input values")]
    [Space]
    [SerializeField] private Vector2 _movementInputVector;
    [SerializeField] private Vector2 _lookInputVector;

    [Header("Character stats")]
    [Space]
    [SerializeField] private int _speed = 10;
    [SerializeField] private int _rotationSpeed = 5;
    [SerializeField] private int _hitPoints = 3;

    private void OnEnable()
    {
        _inputReader = GetComponent<PlayerInputReader>();
        EnableGamePlayInput();
        DontDestroyOnLoad(gameObject);
    }

    private void OnDisable()
    {
        DisableGamePlayInput();
    }

    private void EnableGamePlayInput()
    {
        _inputReader.MoveEvent += Move;
        _inputReader.LookEvent += Look;
        _inputReader.AttackEvent += Attack;
    }

    private void DisableGamePlayInput()
    {
        _inputReader.MoveEvent -= Move;
        _inputReader.LookEvent -= Look;
        _inputReader.AttackEvent -= Attack;
    }

    private void Start()
    {
        PropagateStatsFromSO();
        lookVector = _aim.transform.position;
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
        CalculateAim();
        RotateTurret();
    }

    private void FixedUpdate()
    {


    }

    private void RotateTurret()
    {
        if (_turret != null)
        {
            _turret.LookAt(_aim.transform.position);
        }
    }

    private void CalculateAim()
    {
        lookVector += new Vector3(_lookInputVector.x, 0f, _lookInputVector.y) * _rotationSpeed * Time.deltaTime;
        lookVector = Vector3.ClampMagnitude(lookVector, 10);
        _aim.transform.position = lookVector;
    }

    private void CalculateMovement()
    {
        Vector3 movement = new Vector3(_movementInputVector.x, 0f, _movementInputVector.y);
        movementVector = movement * _speed;
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

    private void OnCollisionExit(Collision other)
    {
        isColliding = false;
    }

}
