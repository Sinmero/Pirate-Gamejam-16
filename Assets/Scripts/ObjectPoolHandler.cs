using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class ObjectPoolHandler : MonoBehaviour
{
    [SerializeField] private Transform _poolHolder;
    private static ObjectPoolHandler _inst;
    public static ObjectPoolHandler instance {get{return _inst;}}
    public Dictionary<string, ObjectPool<GameObject>> _poolDictionary = new Dictionary<string, ObjectPool<GameObject>>();
    [SerializeField] private List<ObjectPool> _objectPoolList = new List<ObjectPool>();
    // private ObjectPool<GameObject> pool;

    void Start()
    {
        if (_inst == null)
        {
            _inst = this; 
        }

        foreach (var item in _objectPoolList)
        {
            SystemLogger.instance.Log($"Creating {item}", this);
            item.Init();
        }
    }



    public ObjectPool<GameObject> SetPool(GameObject thisObject, int poolSize = 10, int maxPoolSize = 10)
    {
        GameObject GO =  thisObject;
        var pool = new ObjectPool<GameObject>(
            () =>
            {
                var newGO = Instantiate(thisObject, Vector3.zero, Quaternion.identity, _poolHolder);
                SystemLogger.instance.Log(newGO.name, this);
                return newGO;
            },
            newGO => {newGO.SetActive(true);},
            newGO => {newGO.SetActive(false);},
            newGO => {Destroy(newGO);},
            true,
            poolSize,
            maxPoolSize
        );
        return pool;
    }
}
