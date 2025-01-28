using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDeath : EnemySpawner
{
    private Living _living;



    void Start()
    {
        _living = GetComponent<Living>();

        _living.IonDeath += DoSpawnOnDeath;
    }



    public void DoSpawnOnDeath() {
        InstantSpawning(_spawnerPoolSO);
    }
}
