using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class OnDamageEffectHandler : MonoBehaviour
{
    private Coroutine _blinkCoroutine;
    private Material _material;
    [SerializeField] private Living _living;
    [SerializeField] private bool _playSecondaryEffects = true;
    private ParticleSystem _particlesSystem;
    private Color32 _color;
    [SerializeField] private List<SpriteRenderer> _spriteRendererList = new();
    private List<Coroutine> _coroutineList = new();

    void Start()
    {
        StartCoroutine(LateStart());
    }



    public IEnumerator LateStart()
    {
        yield return new WaitForEndOfFrame();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (_spriteRendererList.Count > 0)
        {
            _material = _spriteRendererList[0].material;
        }
        else if (sr != null)
        {
            _material = sr.material;
        }

        _color = _material.GetColor("_SpriteColor");

        _particlesSystem = Statics.instance._splatterParticleSystem;

        _living.IonDamageTaken += HandleDamageEffects;
        if (_playSecondaryEffects)
        {
            _living.IonDeath += OnDeathEffects;
            _living.IonDamageTaken += GetDamageNumbers;
        }
    }



    private void HandleDamageEffects(float damage)
    {
        if (_blinkCoroutine != null) StopCoroutine(_blinkCoroutine);
        if (_spriteRendererList == null || _spriteRendererList.Count == 0)
        {
            _blinkCoroutine = StartCoroutine(DamageBlink(0.025f, _material));
            return;
        }

        for (int i = 0; i < _spriteRendererList.Count; i++)

        {

            SpriteRenderer sr = _spriteRendererList[i];

            Material mat = sr.material;

            if (i < _coroutineList.Count)
            {
                StopCoroutine(_coroutineList[i]);
                _coroutineList[i] = StartCoroutine(DamageBlink(0.025f, mat));
            }
            else
            {
                _coroutineList.Add(StartCoroutine(DamageBlink(0.025f, mat)));
            }
        }
    }



    public IEnumerator DamageBlink(float blinkTime, Material material, float step = 0.25f)
    {
        float blinkState = material.GetFloat("_FlashLerp");
        while (blinkState < 1)
        {
            yield return new WaitForSeconds(blinkTime);
            blinkState += step;
            material.SetFloat("_FlashLerp", blinkState);
        }
        while (blinkState > 0)
        {
            yield return new WaitForSeconds(blinkTime);
            blinkState -= step;
            material.SetFloat("_FlashLerp", blinkState);
        }
    }



    private void OnDeathEffects()
    {
        var main = _particlesSystem.main;
        main.startColor = new ParticleSystem.MinMaxGradient(_color);
        _particlesSystem.transform.position = transform.position;
        _particlesSystem.Play();
    }



    private GameObject _damageNumberGO;
    private DamageNumberHandler damageNumberHandler;
    private void GetDamageNumbers(float damage)
    {
        if (_damageNumberGO == null || !_damageNumberGO.activeSelf)
        {
            _damageNumberGO = ObjectPoolHandler.instance._poolDictionary["DamageNumber"].Get();
            _damageNumberGO.transform.position = transform.position;
            damageNumberHandler = _damageNumberGO.GetComponent<DamageNumberHandler>();
        }

        damageNumberHandler._damage = damage;
    }
}
