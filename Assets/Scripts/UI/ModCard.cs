using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModCard : MonoBehaviour, IClickable
{
    [SerializeField] private Image _cardImage;
    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _descriptionTmpro;
    private WeaponModCard _weaponModCard;




    public void SetCard(WeaponModCard weaponModCard) {
        if(weaponModCard._modIcon != null) _iconImage.sprite = weaponModCard._modIcon;
        _descriptionTmpro.text = weaponModCard._modDescription;
        _weaponModCard = weaponModCard;
        _cardImage.sprite = Statics.instance._modCardImageList.Find(x => x._imageName == weaponModCard._rarity)._sprite;

        GameplayLogger.instance.Log($"Card was set to {weaponModCard._modName}", this);
    }



    public void IOnClick() {
        _weaponModCard.ApplyMod(Statics.instance._currentWeapon);
        transform.parent.gameObject.SetActive(false);
    }
}
