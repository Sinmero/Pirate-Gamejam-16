using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModifier
{
    public Bullet _bullet;
    public string _modifierName = "Generic Modifier";



    public BulletModifier(Bullet bullet)
    {
        Init(bullet);
    }



    public virtual void Init(Bullet bullet)
    {
        _bullet = bullet;
        _bullet.onHitIDamagable += OnHitIDamagable;
        _bullet.onActive += OnActive;
        _bullet.onReleased += OnReleased;

        SystemLogger.instance.Log($"{_modifierName} was initialized at {_bullet}", _bullet);
    }



    public virtual void OnHitIDamagable(IDamagable iDamagable, RaycastHit2D hit)
    {

    }



    public virtual void OnActive()
    {

    }



    public virtual void OnReleased()
    {
        Unsub();
    }



    public void Unsub()
    {
        _bullet.onHitIDamagable -= OnHitIDamagable;
        _bullet.onActive -= OnActive;
        _bullet.onReleased -= OnReleased;
    }



    public virtual void AddToExisting(Bullet bullet)
    {
        SystemLogger.instance.Log($"{this} already exists. Invoking adding function.", _bullet);
    }
}
