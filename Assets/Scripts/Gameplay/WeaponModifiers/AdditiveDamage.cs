using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditiveDamage : BulletModifier
{
    public float _additiveDamage  = 5;



    public AdditiveDamage(Bullet bullet) : base(bullet) {

    }



    public override void Init(Bullet bullet)
    {
        base.Init(bullet);
        bullet._additiveDamage += _additiveDamage;
    }



    public override void AddToExisting(Bullet bullet)
    {
        base.AddToExisting(bullet);
        _additiveDamage += 5;
        bullet._additiveDamage += _additiveDamage;
    }
}
