using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    public TextMeshProUGUI _healthTmpro;
    public Player _player;



    void Start()
    {
        _healthTmpro.text = _player._health.ToString();
        _player.onHealthChange += OnPlayerHealthChange;
    }



    public void OnPlayerHealthChange(float health) {
        _healthTmpro.text = health.ToString();
    }
}
