using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringMode : State
{
    [HideInInspector] public Weapon _weapon;
    [HideInInspector] public string _firingModeName = "Default Firing Mode";

    public FiringMode(StateMachine stateMachine) : base(stateMachine)
    {
        _stateMachine = stateMachine;
        _weapon = _stateMachine.GetComponent<Weapon>();

        if (_weapon == null)
        {
            SystemLogger.instance.Log($"No Weapon script attached to {_stateMachine.name}", _stateMachine);
            return;
        }
    }



    public override void OnEnter()
    {
        _weapon._animationMaker._spriteList = _weapon._weaponIdleAnimation;
    }



    public override void OnUpdate()
    {
        base.OnUpdate();
        if (Input.GetKeyDown(Controls.keys._reload) || _weapon._magazineAmmo <= 0) //changing to reloading state
        {
            _weapon.ChangeState(_weapon._reload);
        }
    }
}
