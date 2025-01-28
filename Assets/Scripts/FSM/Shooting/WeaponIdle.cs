using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIdle : FiringMode
{
    public WeaponIdle(StateMachine stateMachine) : base(stateMachine)
    {
        _stateMachine = stateMachine;
        _weapon = _stateMachine.GetComponent<Weapon>();
        _firingModeName = "Idle";

        if (_weapon == null)
        {
            SystemLogger.instance.Log($"No Weapon script attached to {_stateMachine.name}", _stateMachine);
            return;
        }
    }



    public override void OnEnter()
    {
        base.OnEnter();
        _weapon._animationMaker._spriteList = _weapon._weaponIdleAnimation;
        _weapon._animationMaker._minFramesPerSecond = _weapon._weaponIdleAnimation.Count;
        _weapon._animationMaker._maxFramesPerSecond = _weapon._weaponIdleAnimation.Count;
    }



    public override void OnUpdate()
    {
        base.OnUpdate();
        if(Input.GetKey(Controls.keys._shoot)) {
            _weapon.ChangeState(_weapon._firingMode);
        }
    }
}
