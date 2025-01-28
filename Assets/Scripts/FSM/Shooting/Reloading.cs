using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reloading : State
{
    public Weapon _weapon;
    public Coroutine _currentCoroutine;


    public Reloading(StateMachine stateMachine) : base(stateMachine)
    {
        _stateMachine = stateMachine;
    }



    public override void OnEnter()
    {
        base.OnEnter();

        _weapon = _stateMachine.GetComponent<Weapon>();
        if (_weapon == null)
        {
            SystemLogger.instance.Log($"No Weapon script attached to {_stateMachine.name}", _stateMachine);
            return;
        }
        if(_currentCoroutine != null) Statics.instance.DoStopCoroutine(_currentCoroutine); //just in case

        _weapon._animationMaker._minFramesPerSecond = _weapon._weaponReloadingAnimation.Count / _weapon._reloadTime;
        _weapon._animationMaker._maxFramesPerSecond = _weapon._weaponReloadingAnimation.Count / _weapon._reloadTime;
        _weapon._animationMaker._spriteList = _weapon._weaponReloadingAnimation;

        _currentCoroutine = Statics.instance.DoStartCoroutine(Reload());
    }



    private IEnumerator Reload() {
        yield return new WaitForSeconds(_weapon._reloadTime);
        _weapon._magazineAmmo = _weapon._maxMagazineAmmo; //refill the ammo magazine
        _weapon.ChangeState(_weapon._firingMode); //back to shooting
    }
}