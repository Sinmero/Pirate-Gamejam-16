using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    [HideInInspector] public float _projectileSpeed = 1f;
    public float _defaultProjectileSpeed = 1f;
    private float force;
    [HideInInspector] public float _damage = 10;
    public float _defaultDamage = 10f;
    [HideInInspector] public float _additiveDamage = 0;
    public float _defaultAdditiveDamage = 0;
    [HideInInspector] public float _lifeTime = 1;
    public float _defaultLifetime = 1f;
    [HideInInspector] public string _bulletName = "Default name";
    public string _defaultName = "Default name";
    // [HideInInspector] public string _id = "";
    private TrailRenderer _trailRenderer;
    [HideInInspector] public bool _destroyOnHit = true; //this is used for piercing and stuff


    public delegate void OnHitIDamagable(IDamagable iDamagable, RaycastHit2D raycastHit2D);
    public event OnHitIDamagable onHitIDamagable;
    public delegate void OnActive();
    public event OnActive onActive;
    public delegate void OnReleased();
    public event OnReleased onReleased;
    public Dictionary<string, BulletModifier> _bulletModifierDict = new Dictionary<string, BulletModifier>();
    [HideInInspector] public List<GameObject> _hitList = new();


    private void Start()
    {
        onActive?.Invoke();
        force = rb.mass * _projectileSpeed / Time.fixedDeltaTime;
        _trailRenderer = GetComponent<TrailRenderer>();
    }



    public void FullReset()
    {
        ResetToDefault();
        foreach (KeyValuePair<string, BulletModifier> obj in _bulletModifierDict)
        {
            obj.Value.Unsub();
        }
        _bulletModifierDict.Clear();
    }



    public void ResetToDefault()
    {
        _projectileSpeed = _defaultProjectileSpeed;
        _damage = _defaultDamage;
        _lifeTime = _defaultLifetime;
        _bulletName = _defaultName;
        _additiveDamage = _defaultAdditiveDamage;
        _destroyOnHit = true;
        _hitList.Clear();
    }



    private void FixedUpdate()
    {
        RayCastCheck();
    }



    private void OnEnable()
    {
        StartCoroutine(Accelerate());

        FullReset();


        // _bulletModifierDict.Clear(); //clear all the bullet mods on pulling bullet from objectpool. Every time the bullet gets pulled it recieves mods from the weapon. We dont want the same mods to stack on top of each other.

        onActive?.Invoke();

        if (_releaseTimer != null) StopCoroutine(_releaseTimer); //prevent release coroutine from stacking
        _releaseTimer = StartCoroutine(ReleaseTimer());
        StartCoroutine(EnableDelay());
    }



    private void OnDisable()
    {
        onReleased?.Invoke();
        if (_trailRenderer != null) _trailRenderer.enabled = false;
    }



    private IEnumerator Accelerate()
    {
        yield return new WaitForEndOfFrame();
        rb.AddForce((Vector2)transform.right * force);
    }



    private Coroutine _releaseTimer;
    private IEnumerator ReleaseTimer()
    {
        yield return new WaitForSeconds(_lifeTime);
        ObjectPoolHandler.instance._poolDictionary[_bulletName].Release(gameObject);
    }



    private IEnumerator EnableDelay()
    { //this is done because the projectile spawns away from the shooting point and it takes 1 frame to move it there
        yield return new WaitForEndOfFrame();
        if (_trailRenderer != null) ClearTrailRenderer();
    }



    private void ClearTrailRenderer()
    {
        _trailRenderer.Clear();
        _trailRenderer.enabled = true;
    }



    public virtual void RayCastCheck()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, rb.velocity.normalized, rb.velocity.magnitude * Time.deltaTime, ~(1 << gameObject.layer));

        if (hits == null) return;
        foreach (RaycastHit2D h in hits)
        {
            IDamagable hitIDamagable = h.collider.GetComponent<IDamagable>();

            if (_hitList.Contains(h.collider.gameObject)) continue; //prevent damaging the same object twice
            _hitList.Add(h.collider.gameObject);

            if (hitIDamagable != null) hitIDamagable.ITakeDamage(_damage + _additiveDamage);
            transform.position = h.point; //move bullet to hit point location
            OnHit(hitIDamagable, h);
            break;
        }
    }



    public virtual void OnHit(IDamagable hitIdamagable, RaycastHit2D hit)
    {
        if(hitIdamagable != null) onHitIDamagable?.Invoke(hitIdamagable, hit);

        if (!_destroyOnHit) return;

        if (_releaseTimer != null) StopCoroutine(ReleaseTimer()); //we dont want release coroutine to release already released object

        ObjectPoolHandler.instance._poolDictionary[_bulletName].Release(gameObject);
    }
}
