using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemySpawnPool _spawnerPoolSO;
    [SerializeField] private float _minSpawnDistance = 5;
    [SerializeField] private GameObject _spawnParentGO;
    public float _spawnSpeed = 0.5f;
    public int _spawnAmount = 10;
    public bool _infiniteSpawning = false,
    _spawnFromStart = true;
    public string _specificSpawnName = "";
    private Coroutine _currentCoroutine;



    void Start()
    {
        if (_spawnFromStart) _currentCoroutine = StartCoroutine(SpawnTimer(_spawnerPoolSO));
    }



    private (Vector3, bool overAttempts) GetSpawnLocation(float spawnedObjectScale, int attempts = 0)
    {
        float spawnDistance = _minSpawnDistance + attempts;

        Vector3 pos = transform.position + new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0).normalized * spawnDistance;

        RaycastHit2D hit = Physics2D.BoxCast(pos, Vector2.one * spawnedObjectScale, 0, Vector2.zero); //check if there are any obstacles in the spawnpoint

        if (attempts >= 7)
        {
            PhysicsLogger.instance.Log($"Failed to find spawn position", this);
            return (pos, true);
        }

        if (hit.collider != null)
        { //try again if there is an obstacle
            PhysicsLogger.instance.Log($"Boxcast collided with {hit.collider.name} at {hit.point} with {Vector2.one * spawnedObjectScale} size at {spawnedObjectScale} scale", this);

            int atm = attempts + 1;
            return GetSpawnLocation(spawnedObjectScale, atm);
        }

        return (pos, false);
    }



    public GameObject RollFromSpawnPool(EnemySpawnPool enemySpawnPool)
    {
        if (_specificSpawnName != "") return enemySpawnPool._enemySpawnData.Find(x => x._name == _specificSpawnName)._spawnGO;

        string rarity = Statics.instance.RarityRoll(Statics.instance._enemyRarity);
        
        List<EnemySpawnData> spawnList = enemySpawnPool._enemySpawnData.FindAll(x => x._rarity == rarity);

        if (spawnList.Count == 0) return RollFromSpawnPool(enemySpawnPool); //try again if nothing spawned

        int returnIndex = Random.Range(0, spawnList.Count);

        return spawnList[returnIndex]._spawnGO;

        // foreach (EnemySpawnData data in enemySpawnPool._enemySpawnData)
        // {
        //     // float chance = UnityEngine.Random.Range(0, 100);


        //     if (chance < data._spawnChance)
        //     {
        //         SystemLogger.instance.Log($"Picked {data._spawnGO.name} for spawning", this);
        //         return data._spawnGO;
        //     }
        // }

        // return RollFromSpawnPool(enemySpawnPool); //try again if nothing spawned
    }



    public IEnumerator SpawnTimer(EnemySpawnPool spawnerPoool)
    {
        for (int i = 0; i < _spawnAmount; i++)
        {
            GameObject GO = RollFromSpawnPool(spawnerPoool);

            GameObject parent = _spawnParentGO;

            if(_spawnParentGO == null) parent = transform.parent.gameObject;

            yield return new WaitForSeconds(_spawnSpeed);
            (Vector3 pos, bool overAttempts) = GetSpawnLocation(GO.transform.localScale.x);
            if (!overAttempts && Statics.instance._currentEnemies < Statics.instance._maxEnemies) Instantiate(GO, pos, Quaternion.identity, parent.transform); //spawn
        }

        if (_infiniteSpawning)
        { //repeat if set to infinite spawning
            _currentCoroutine = StartCoroutine(SpawnTimer(_spawnerPoolSO));
        }
    }



    public void InstantSpawning(EnemySpawnPool spawnerPoool)
    {
        for (int i = 0; i < _spawnAmount; i++)
        {
            GameObject GO = RollFromSpawnPool(spawnerPoool);

            GameObject parent = _spawnParentGO;

            if(_spawnParentGO == null) parent = transform.parent.gameObject;

            (Vector3 pos, bool overAttempts) = GetSpawnLocation(GO.transform.localScale.x);
            if (!overAttempts && Statics.instance._currentEnemies < Statics.instance._maxEnemies) Instantiate(GO, pos, Quaternion.identity, parent.transform); //spawn
        }
    }
}