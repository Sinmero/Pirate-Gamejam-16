using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModCardsHandler : MonoBehaviour
{
    public List<ModCard> _modCardList = new();



    private void OnEnable() { //fill the cards with mod data when enabled
        foreach(ModCard obj in _modCardList) {
            WeaponModCard weaponModCard = RollUpgrade();
            obj.SetCard(weaponModCard);
        }
    }



    public WeaponModCard RollUpgrade() {
        string rarity =  Statics.instance.RarityRoll(Statics.instance._upgradeRarity);
        List<WeaponModCard> modList = Statics.instance._weaponModCards.FindAll(x => x._rarity == rarity);
        WeaponModCard card = modList[Random.Range(0, modList.Count)];
        return card;
    }
}
