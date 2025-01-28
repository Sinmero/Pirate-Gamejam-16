using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class DamageNumberHandler : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _numberSpeed = 1;
    [SerializeField] private float _lifeTime = 1;
    private Vector2 _moveVector = new Vector2(0,0);
    private TextMeshPro _tmpro;
    private float _dmg = 0;
    [HideInInspector] public float _damage {get{return _dmg;} set{_dmg += value; SetNumber(_dmg);}}



    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _tmpro = GetComponent<TextMeshPro>();

        _moveVector.y = _numberSpeed;

        _rb.velocity = _moveVector;

        SetNumber(_dmg);
    }



    private void OnEnable() {
        _rb.velocity = _moveVector;
        if(_releaseTimer != null) StopCoroutine(_releaseTimer);
        StartCoroutine(ReleaseTimer());
    }



    private void OnDisable() {
        _dmg = 0;
        _damage = 0;
    }



    private void SetNumber(float num) {
        _tmpro.text = num.ToString();
        float invLerp = Mathf.InverseLerp(0, 500, num);
        float fontSize = math.lerp(4, 12, invLerp);
        _tmpro.fontSize = math.round(fontSize);
    }



    private Coroutine _releaseTimer;
    private IEnumerator ReleaseTimer() {
        yield return new WaitForSeconds(_lifeTime);
        ObjectPoolHandler.instance._poolDictionary["DamageNumber"].Release(gameObject);
    }
}
