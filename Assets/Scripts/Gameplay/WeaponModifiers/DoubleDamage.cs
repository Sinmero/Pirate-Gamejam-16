using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamage : BulletModifier
{
    public DoubleDamage(Bullet bullet) : base(bullet) {

    }



    public override void Init(Bullet bullet)
    {
        _modifierName = "Double Damage";
        base.Init(bullet);
        Statics.instance.DoStartCoroutine(LateStart(bullet));
    }



    public IEnumerator LateStart(Bullet bullet) { //this is done to apply x2 damage after all additive mod were applied
        yield return new WaitForEndOfFrame();
        bullet._damage *= 2;
    }
}
