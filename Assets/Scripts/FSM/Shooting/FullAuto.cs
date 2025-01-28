using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAuto : FiringMode
{
    private float nextShotTime;

    public FullAuto(StateMachine stateMachine): base(stateMachine) {
        _stateMachine = stateMachine;
        _firingModeName = "Full Auto";
    }



    public override void OnEnter()
    {
        base.OnEnter();
        nextShotTime = Time.time;
    }



    public override void OnUpdate()
    {
        base.OnUpdate();
        if (Input.GetKey(Controls.keys._shoot))
        {
            if (Time.time < nextShotTime) return;

            nextShotTime = Time.time + (1 / _weapon._firerate);
            _weapon.SpawnProjectile();
        } else
        {
            _weapon.ChangeState(_weapon._weaponIdle);
        }
    }
}
