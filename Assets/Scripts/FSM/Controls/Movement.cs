using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Movement : State
{
    public Rigidbody2D _rb;
    public PlayerStateMachine _playerStateMachine;
    private Vector2 _targetMoveVector = new Vector2(0, 0);
    private Vector2 _moveVector = new Vector2(0, 0);


    public Movement(StateMachine stateMachine) : base(stateMachine)
    {
        _stateMachine = stateMachine;
        _rb = _stateMachine.GetComponent<Rigidbody2D>();
        if (_rb == null) SystemLogger.instance.Log($"{_stateMachine.gameObject.name} has no RigidBody2d attached to it.", _stateMachine);
        _playerStateMachine = _stateMachine as PlayerStateMachine;
    }


    public override void OnUpdate()
    {
        base.OnUpdate();

        if (Input.GetKeyDown(Controls.keys._up))
        {
            _targetMoveVector.y += 1;
        }
        if (Input.GetKeyDown(Controls.keys._down))
        {
            _targetMoveVector.y += -1;
        }
        if (Input.GetKeyDown(Controls.keys._left))
        {
            _targetMoveVector.x += -1;
        }
        if (Input.GetKeyDown(Controls.keys._right))
        {
            _targetMoveVector.x += 1;
        }
        if (Input.GetKeyUp(Controls.keys._up))
        {
            _targetMoveVector.y -= 1;
        }
        if (Input.GetKeyUp(Controls.keys._down))
        {
            _targetMoveVector.y -= -1;
        }
        if (Input.GetKeyUp(Controls.keys._left))
        {
            _targetMoveVector.x -= -1;
        }
        if (Input.GetKeyUp(Controls.keys._right))
        {
            _targetMoveVector.x -= 1;
        }

        if(!Application.isFocused) {
            _targetMoveVector = Vector2.zero;
            _moveVector = Vector2.zero;
            _rb.velocity = _moveVector;
        }

        _moveVector = math.lerp(_moveVector, _targetMoveVector, Time.deltaTime * _playerStateMachine._accleleration); //smooth movement

        if(_moveVector.x < 0) _playerStateMachine.FlipOutfit(true);
        if(_moveVector.x > 0) _playerStateMachine.FlipOutfit(false);

        if (_moveVector.magnitude > 0)
        {
            _rb.velocity = _moveVector.normalized * math.clamp(_moveVector.magnitude, -1, 1) * _playerStateMachine._moveSpeed;
        }
    }

}
