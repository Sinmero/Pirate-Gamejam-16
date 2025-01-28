using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomSprites", menuName = "ScriptableObjects/SpriteList")]
public class RandomSpriteSO : ScriptableObject
{
    public List<Sprite> _spriteList = new List<Sprite>();
}
