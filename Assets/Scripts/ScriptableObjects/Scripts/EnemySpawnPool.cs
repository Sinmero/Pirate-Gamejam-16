using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnPool", menuName = "ScriptableObjects/SpawnPool"), System.Serializable]
public class EnemySpawnPool : ScriptableObject
{
    public string _poolName = "Default pool";
    public List<EnemySpawnData> _enemySpawnData = new List<EnemySpawnData>();



}

[System.Serializable]
public class EnemySpawnData {
    public float _spawnChance;
    public string _rarity = "Common";
    public string _name = "Default Name";
    public GameObject _spawnGO;
}