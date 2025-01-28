using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SlimeAI : StateMachine
{
    public State _chase;
    public float _speed = 3,
    _damage = 5,
    _damageTickRate = 0.25f;

    [HideInInspector] public Rigidbody2D rb;
    private Coroutine _currentCoroutine;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _chase = new ChasePlayer(this);
        ChangeState(_chase);
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        Player player = other.collider.gameObject.GetComponent<Player>();

        if (player != null)
        {
            if(_currentCoroutine != null) StopCoroutine(_currentCoroutine);
            _currentCoroutine = StartCoroutine(DealDamage(player));
        }
    }



    private void OnCollisionExit2D(Collision2D other)
    {
        Player player = other.collider.gameObject.GetComponent<Player>();

        if (player != null)
        {
            StopCoroutine(_currentCoroutine);
        }
    }



    public IEnumerator DealDamage(IDamagable playerIDamagable)
    {

        while (true)
        {
            playerIDamagable.ITakeDamage(_damage);
            yield return new WaitForSeconds(_damageTickRate);
        }
    }
}
