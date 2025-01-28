using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Living : MonoBehaviour, IDamagable
{
    public float _maxHealth = 50;
    public float _currentHealth = 50;
    public float _health {get {return _currentHealth;} set {_currentHealth = value; onHealthChange?.Invoke(_currentHealth);}}
    [Range(0, 100)] public float _armor;
    public event IDamagable.IOnDamageTaken IonDamageTaken;
    public event IDamagable.IOnDeath IonDeath;
    public delegate void OnHealthChange(float health);
    public event OnHealthChange onHealthChange;



    public virtual void ITakeDamage(float damage) {
        float dmg = math.round(damage * (1 - _armor/100));

        _health = math.floor(_health - dmg);

        IonDamageTaken?.Invoke(dmg);

        GameplayLogger.instance.Log($"{name} took {dmg}. {_health} amouth of health remains", this);

        if(_health <= 0) OnDeath();
    }



    public virtual void OnDeath() {
        GameplayLogger.instance.Log($"{name} died", this);

        IonDeath?.Invoke();
        Destroy(gameObject);
    }
}
