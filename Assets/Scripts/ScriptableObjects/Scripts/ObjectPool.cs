using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ObjectPool", menuName = "ScriptableObjects/ObjectPool"), System.Serializable]
public class ObjectPool : ScriptableObject
{
    [SerializeField] private string _objectPoolName = "Default Name";
    [SerializeField] private GameObject _pooledObject;
    [SerializeField] private int _poolSize = 0, _maxPoolSize = 10;


    public void Init() {
        var pool = ObjectPoolHandler.instance.SetPool(_pooledObject, _poolSize, _maxPoolSize);
        SystemLogger.instance.Log($"{_objectPoolName} was instantiated {pool.CountAll}", this);
        ObjectPoolHandler.instance._poolDictionary.Add(_objectPoolName, pool);
    }
}
