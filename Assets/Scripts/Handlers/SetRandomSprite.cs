using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SetRandomSprite : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private RandomSpriteSO _spriteListSO;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        RandomSprite();
    }



    private void RandomSprite() {
        int listLength = _spriteListSO._spriteList.Count;

        int index = (int) math.floor(UnityEngine.Random.Range(0, listLength - 1));

        _spriteRenderer.sprite = _spriteListSO._spriteList[index];
    }
}
