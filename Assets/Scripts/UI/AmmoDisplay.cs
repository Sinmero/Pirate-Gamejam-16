using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoDisplay : MonoBehaviour
{
    public TextMeshProUGUI _tmpro;

    

    void Start()
    {
        Statics.instance.onWeaponChange += SubscribeToAmmoChangeEvent;
        SubscribeToAmmoChangeEvent(Statics.instance._currentWeapon);
        _tmpro.text = Statics.instance._currentWeapon._maxMagazineAmmo.ToString();
    }



    public void SubscribeToAmmoChangeEvent(Weapon weapon) {
        weapon.onAmmoChange += ChangeAmmoText;
        _tmpro.text = Statics.instance._currentWeapon._maxMagazineAmmo.ToString();
    }



    public void ChangeAmmoText(float ammo) {
        _tmpro.text = ammo.ToString();
    }
}
