using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAuto : FiringMode
{
    private float nextShotTime;
    private bool _didShoot = false;

    public SemiAuto(StateMachine stateMachine): base(stateMachine) {
        _stateMachine = stateMachine;
    }



    public override void OnEnter()
    {
        base.OnEnter();
        nextShotTime = Time.time;
        _firingModeName = "Semi Auto";
    }
    


    public override void OnUpdate()
    {
        base.OnUpdate();
        if (Input.GetKey(Controls.keys._shoot))
        {
            if (Time.time < nextShotTime || _didShoot) return;

            nextShotTime = Time.time + (1 / _weapon._firerate);
            _weapon.SpawnProjectile();
            _didShoot = true;
        } else
        {
            _weapon.ChangeState(_weapon._weaponIdle);
        }

        if(Input.GetKeyUp(Controls.keys._shoot)) {
            _didShoot = false;
        }
    }
}
