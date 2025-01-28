using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponMod", menuName = "ScriptableObjects/WeaponMod")]
public class WeaponModCard : ScriptableObject
{
    public Sprite _modIcon;
    public string _modName = "Default mod";
    public string _modDescription = "No description";
    public string _rarity = "Common";
    public string _modInitializerClassName = "None"; //put the name of the initializer class that would handle the weapon mod
    public bool _isBulletMod = true;


    // public void AddModToBullet(Weapon weapon) {
    //     weapon.AddModInitializerToBullet(_modInitializerClassName);

    //     GameplayLogger.instance.Log($"{_modInitializerClassName} was added to {weapon}", this);
    // }



    public void ApplyMod(Weapon weapon) {
        if(_isBulletMod) {
            weapon.AddModInitializerToBullet(_modInitializerClassName);
            GameplayLogger.instance.Log($"{_modInitializerClassName} was added to {weapon}", this);
            return;
        }
        weapon.AddModInitializer(_modInitializerClassName);

        GameplayLogger.instance.Log($"{_modInitializerClassName} was added to {weapon}", this);
    }
}
