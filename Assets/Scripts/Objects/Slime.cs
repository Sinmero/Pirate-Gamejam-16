using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Living
{
    public float _minSize = 1,
    _maxSize = 1;
    public int _expOnDeath = 50;
    


    private void Start() {
        Statics.instance._currentEnemies++;
        StartCoroutine(LateStart());
    }



    public override void OnDeath()
    {
        base.OnDeath();
        Statics.instance._currentEnemies--;
        Statics.instance._currentEXP += _expOnDeath;
    }



    public IEnumerator LateStart() {
        yield return new WaitForEndOfFrame();
        transform.localScale = new Vector3(1,1,1) * Random.Range(_minSize, _maxSize);
    }
}
