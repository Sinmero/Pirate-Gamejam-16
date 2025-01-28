using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    public delegate void IOnDamageTaken(float damage);
    event IOnDamageTaken IonDamageTaken;
    public delegate void IOnDeath();
    event IOnDeath IonDeath;


    public void ITakeDamage(float damage) {}
}




public interface IClickable {
    public void IOnClick(){}
}