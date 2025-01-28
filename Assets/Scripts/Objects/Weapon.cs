using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : StateMachine
{
    public GameObject _shootingPoint;
    public Bullet _bulletPrefab;
    public float _firerate = 0.5f,
    _spread = 0,
    _maxMagazineAmmo = 20f,
    _reloadTime = 1.5f,
    _ammoSpent = 1,
    _projectilesPerShot = 1;
    [SerializeField] private float _ammo = 20f;
    public float _magazineAmmo { get { return _ammo; } set { _ammo = value; onAmmoChange?.Invoke(_ammo); } }

    public delegate void OnAmmoChange(float ammo);
    public event OnAmmoChange onAmmoChange;
    // [HideInInspector] public string _id = "";

    public State _firingMode;
    public State _reload;
    public State _weaponIdle;
    private quaternion _spreadQ;
    [SerializeField] private ParticleSystem _shellParticleSystem;
    [SerializeField] private ParticleSystem _muzzleFlashParticleSystem;
    [HideInInspector] public AnimationMaker _animationMaker;

    public List<Sprite> _weaponIdleAnimation = new List<Sprite>();
    public List<Sprite> _weaponShootingAnimation = new List<Sprite>();
    public List<Sprite> _weaponReloadingAnimation = new List<Sprite>();

    private List<ModifierInitializer> _modInitist = new();
    public List<ModifierInitializer> _bulletInitializerList { get { return _modInitist; } set { _modInitist = value;} }
    private List<ModifierInitializer> _modInitListWeapon = new();
    public List<ModifierInitializer> _weaponInitializerList { get { return _modInitListWeapon; } set { _modInitListWeapon = value;}}



    private void Start()
    {
        Statics.instance._weaponModCardsDict["Weapon Fire Rate"].ApplyMod(this);
        Statics.instance._weaponModCardsDict["Weapon Fire Rate"].ApplyMod(this);
        Statics.instance._weaponModCardsDict["Weapon Fire Rate"].ApplyMod(this);

        Init();
    }



    public virtual void Init()
    {
        _firingMode = new FullAuto(this);
        _reload = new Reloading(this);
        _weaponIdle = new WeaponIdle(this);
        _animationMaker = GetComponent<AnimationMaker>();

        Statics.instance._currentWeapon = this;

        ChangeState(_firingMode);

        // _id = BuildId();
    }



    public void SpawnProjectile(int projectilesAmout = 0)
    {
        for (int i = 0; i < projectilesAmout + _projectilesPerShot; i++)
        {
            DoSpawnProjectile();
        }
    }



    public virtual void DoSpawnProjectile()
    {
        _spreadQ = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + UnityEngine.Random.Range(-_spread, _spread)); //some spread math

        GameObject bullet = ObjectPoolHandler.instance._poolDictionary[_bulletPrefab._bulletName].Get();
        bullet.transform.position = _shootingPoint.transform.position;
        bullet.transform.rotation = _spreadQ;

        Bullet b = bullet.GetComponent<Bullet>();

        foreach (ModifierInitializer obj in _bulletInitializerList)
        {
            // b._id += obj._modifierName;
            obj.Init(b, this);
        }

        _shellParticleSystem.Play();
        _muzzleFlashParticleSystem.Play();

        _magazineAmmo -= _ammoSpent;
    }



    public void AddModInitializerToBullet(string className)
    {
        Type type = Type.GetType(className);
        ModifierInitializer modifierInitializer = (ModifierInitializer)Activator.CreateInstance(type);

        _bulletInitializerList.Add(modifierInitializer);
    }



    public void AddModInitializer(string className)
    {
        Type type = Type.GetType(className);
        ModifierInitializer modifierInitializer = (ModifierInitializer)Activator.CreateInstance(type);

        _weaponInitializerList.Add(modifierInitializer);
        InitWeaponMods();
    }



    public void InitWeaponMods () {
        Debug.Log("INITIGN EPTA!");
        foreach (ModifierInitializer obj in _modInitListWeapon)
        {
            obj.Init(null, this);
        }
    }



    // public string BuildId()
    // {
    //     string id = "";
    //     foreach (ModifierInitializer obj in _bulletInitializerList)
    //     {
    //         id += obj._modifierName;
    //     }
    //     return id;
    // }
}
