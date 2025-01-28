using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePierce : BulletModifier
{
    public int _maxPierce = 1;
    public int _amountPierced = 0;


    public ProjectilePierce(Bullet bullet) : base(bullet)
    {

    }



    public override void Init(Bullet bullet)
    {
        _modifierName = "Projectile Pierce";
        base.Init(bullet);
    }



    public override void OnHitIDamagable(IDamagable iDamagable, RaycastHit2D hit)
    {
        base.OnHitIDamagable(iDamagable, hit);
        if(_amountPierced < _maxPierce) {_amountPierced++; _bullet._destroyOnHit = false; return;}
        _bullet._destroyOnHit = true;
    }



    public override void AddToExisting(Bullet bullet)
    {
        base.AddToExisting(bullet);
        _maxPierce++;
    }



    public override void OnReleased()
    {
        base.OnReleased();
        _amountPierced = 0;
    }
}
