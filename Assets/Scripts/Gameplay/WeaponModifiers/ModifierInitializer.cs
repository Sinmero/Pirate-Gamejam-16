using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ModifierInitializer
{
    public string _modifierName = "Generic Modifier";
    public BulletModifier _bulletModifier;

    public ModifierInitializer() {
        Init();
    }

    public virtual void Init(Bullet bullet, Weapon weapon = null)
    {

        DictionaryCheck(bullet);
    }



    public virtual void Init() {}



    public bool DictionaryCheck(Bullet bullet)
    {

        if (bullet._bulletModifierDict.ContainsKey(_modifierName))
        { //prevent adding multiple same mods to dictionary
            bullet._bulletModifierDict[_modifierName].AddToExisting(bullet);
            GameplayLogger.instance.Log($"{_modifierName} already exists", bullet);
            return true;
        }
        return false;
    }
}



public class DoubleDamageInitializer : ModifierInitializer
{
    public override void Init(Bullet bullet, Weapon weapon = null)
    {
        // _modifierName = "Double Damage";

        if (!DictionaryCheck(bullet))
        {
            bullet._bulletModifierDict.Add(_modifierName, new DoubleDamage(bullet));
        }
    }



    public override void Init()
    {
        base.Init();
        _modifierName = "Double Damage";
    }
}



public class SplitInitializer : ModifierInitializer
{
    public override void Init(Bullet bullet, Weapon weapon = null)
    {

        // _modifierName = "Projectile Split";

        if (!DictionaryCheck(bullet))
        {
            bullet._bulletModifierDict.Add(_modifierName, new ProjectileSplit(bullet));

        }
    }



    public override void Init()
    {
        base.Init();
        _modifierName = "Projectile Split";
    }
}



public class PierceInitializer : ModifierInitializer
{
    public override void Init(Bullet bullet, Weapon weapon = null)
    {

        // _modifierName = "Projectile Pierce";

        if (!DictionaryCheck(bullet))
        {
            bullet._bulletModifierDict.Add(_modifierName, new ProjectilePierce(bullet));

        }
    }



    public override void Init()
    {
        base.Init();
        _modifierName = "Projectile Pierce";
    }
}



public class AdditiveDamageInitializer : ModifierInitializer
{
    public override void Init(Bullet bullet, Weapon weapon = null)
    {

        if (!DictionaryCheck(bullet))
        {
            bullet._bulletModifierDict.Add(_modifierName, new AdditiveDamage(bullet));

        }
    }



    public override void Init()
    {
        base.Init();
        _modifierName = "Additive Damage";
    }
}



public class WeaponFireRateInitializer : ModifierInitializer
{
    public float _fireRateIncrease = 2;
    private bool _isApplied = false;



    public override void Init(Bullet bullet, Weapon weapon = null)
    {
        if(_isApplied) return; //prevent from applying multiple times
        weapon._firerate += _fireRateIncrease;
        weapon._spread += 2;
        _isApplied = true;
    }



    public override void Init()
    {
        base.Init();
        _modifierName = "Weapon Fire Rate";
    }
}



public class WeaponReloadTimeInitializer : ModifierInitializer
{
    public float _reloadTimeMulti = 0.8f;
    private bool _isApplied = false;



    public override void Init(Bullet bullet, Weapon weapon = null)
    {
        if(_isApplied) return; //prevent from applying multiple times
        weapon._reloadTime *= _reloadTimeMulti;
        _isApplied = true;
    }



    public override void Init()
    {
        base.Init();
        _modifierName = "Weapon Reload Time";
    }
}



public class WeaponAmmoMultiInitializer : ModifierInitializer
{
    public float _ammoMulti = 1.2f;
    private bool _isApplied = false;



    public override void Init(Bullet bullet, Weapon weapon = null)
    {
        if(_isApplied) return; //prevent from applying multiple times
        weapon._maxMagazineAmmo = math.round(weapon._maxMagazineAmmo *_ammoMulti);
        _isApplied = true;
    }



    public override void Init()
    {
        base.Init();
        _modifierName = "Weapon Ammo Multi";
    }
}



public class WeaponProjectilesPerShotInitializer : ModifierInitializer
{
    public int _addProjectiels = 2;
    private bool _isApplied = false;



    public override void Init(Bullet bullet, Weapon weapon = null)
    {
        if(_isApplied) return; //prevent from applying multiple times
        weapon._projectilesPerShot *= _addProjectiels;
        _isApplied = true;
    }



    public override void Init()
    {
        base.Init();
        _modifierName = "Weapon Add Projectiles";
    }
}