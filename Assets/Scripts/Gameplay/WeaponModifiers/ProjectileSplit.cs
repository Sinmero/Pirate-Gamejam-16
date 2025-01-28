using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSplit : BulletModifier
{
    public int _projectilesAmount = 2;
    public int _projectilesSpawned = 0;


    public ProjectileSplit(Bullet bullet) : base(bullet)
    {

    }



    public override void Init(Bullet bullet)
    {
        _modifierName = "Projectile Split";
        base.Init(bullet);
    }



    public override void OnHitIDamagable(IDamagable iDamagable, RaycastHit2D hit)
    {
        base.OnHitIDamagable(iDamagable, hit);

        Unsub(); //prevent from split recurring in new spawned projectiles
        _bullet._bulletModifierDict.Remove(_modifierName);


        for (int i = 0; i < _projectilesAmount; i++)
        {
            if(_projectilesSpawned >= _projectilesAmount) return; //prevent spawning more projectiles than needed
            _projectilesSpawned++;
            Quaternion _spreadQ = Quaternion.Euler(0, 0, _bullet.transform.rotation.eulerAngles.z + UnityEngine.Random.Range(-15, 15)); //some spread math

            GameObject bullet = ObjectPoolHandler.instance._poolDictionary[_bullet._bulletName].Get();

            Bullet b = bullet.GetComponent<Bullet>();
            b._bulletModifierDict = new(_bullet._bulletModifierDict);
            b._hitList = new(_bullet._hitList);

            bullet.transform.position = _bullet.transform.position;
            bullet.transform.rotation = _spreadQ;

        }
    }



    public override void AddToExisting(Bullet bullet)
    {
        base.AddToExisting(bullet);
        _projectilesAmount++;
    }



    public override void OnReleased()
    {
        base.OnReleased();
        _projectilesSpawned = 0;
    }
}
