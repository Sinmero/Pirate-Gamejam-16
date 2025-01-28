using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Statics : MonoBehaviour
{
    private static Statics _statics;
    public static Statics instance {get{return _statics;}}
    public Player _player;
    public int _maxEnemies = 150;
    public int _currentEnemies = 0;
    private int _currEXP = 0;
    [HideInInspector] public int _currentEXP {get{return _currEXP;} set{_currEXP = value; onExpChange?.Invoke(_currentEXP);}}
    public int _nextLevelEXP = 200;
    public delegate void OnExpChange(int exp);
    public event OnExpChange onExpChange;
    public ParticleSystem _splatterParticleSystem;
    public delegate void OnWeaponChange(Weapon weapon);
    public event OnWeaponChange onWeaponChange;
    private Weapon _wpn;
    [HideInInspector] public Weapon _currentWeapon {get{return _wpn;} set{_wpn = value; onWeaponChange?.Invoke(_wpn);}}
    public Dictionary<string, WeaponModCard> _weaponModCardsDict = new();
    public List<WeaponModCard> _weaponModCards = new();
    public List<ImageHolder> _modCardImageList = new();
    public RarityRatings _enemyRarity = new RarityRatings(100, 20, 5, 1);
    public RarityRatings _upgradeRarity = new RarityRatings(100, 20, 5, 1);
    


    void Awake()
    {
        if(_statics == null) _statics = this;
        Init();
    }



    private void Init(){
        foreach(WeaponModCard obj in _weaponModCards) {
            _weaponModCardsDict.Add(obj._modName, obj);
        }
    }



    public Vector2 GetForwardVector(Transform transform)
    {
        float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        float cos = Mathf.Cos(angle);
        float sin = Mathf.Sin(angle);
        Vector2 vector = new Vector2(cos, sin);
        return vector;
    }



    public Coroutine DoStartCoroutine(IEnumerator coroutine) {
        if (coroutine == null) {
            SystemLogger.instance.Log($"coroutine is null", this);
            return null;
        }
        return StartCoroutine(coroutine);
    }



    public void DoStopCoroutine(Coroutine coroutine) {
        StopCoroutine(coroutine);
    }



    public string RarityRoll(RarityRatings rarityRatings) {
        float chance = UnityEngine.Random.Range(0,100);
        if(chance <= rarityRatings._legendary) return "Legendary";
        if(chance <= rarityRatings._rare) return "Rare";
        if(chance <= rarityRatings._uncommon) return "Uncommon";
        return "Common";
    }
}




public struct RarityRatings {
    public RarityRatings(float common, float uncommon, float rare, float legendary) {
        _common = common;
        _uncommon = uncommon;
        _rare = rare;
        _legendary = legendary;
    }

    public float _common,
    _uncommon,
    _rare,
    _legendary;
}


[Serializable]
public class ImageHolder {
    public string _imageName = "";
    public Sprite _sprite;
}