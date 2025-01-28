using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class EXPHandler : MonoBehaviour
{
    private TextMeshProUGUI _tmpro;
    public delegate void OnLevelUp();
    public event OnLevelUp onLevelUp;
    [SerializeField] private GameObject _modCardhandler;




    void Start()
    {
        _tmpro = GetComponent<TextMeshProUGUI>();
        _tmpro.text = Statics.instance._currentEXP + " / " + Statics.instance._nextLevelEXP;
        Statics.instance.onExpChange += OnExpChange;
    }



    public void OnExpChange(int exp)
    {
        int currentExp = exp;
        if (_modCardhandler.activeSelf == true) //if we have a levelup upgrade menu prevent from another levelup upgrade from overlapping
        {
            _tmpro.text = currentExp + " / " + Statics.instance._nextLevelEXP;
            return;
        }
        if (exp >= Statics.instance._nextLevelEXP)
        {
            currentExp -= Statics.instance._nextLevelEXP;
            Statics.instance._nextLevelEXP = (int) math.round(Statics.instance._nextLevelEXP * 1.5f);
            Statics.instance._currentEXP = currentExp;
            _tmpro.text = currentExp + " / " + Statics.instance._nextLevelEXP; //level up

            onLevelUp?.Invoke();

            return;
        }
        _tmpro.text = currentExp + " / " + Statics.instance._nextLevelEXP;
    }
}
