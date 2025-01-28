using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpHandler : MonoBehaviour
{
    public EXPHandler _expHandler;
    public GameObject _modCardsContainerGO;


    void Start()
    {
        _expHandler.onLevelUp += OnLevelUp;
    }



    public void OnLevelUp() {
        _modCardsContainerGO.SetActive(true);
    }
}
