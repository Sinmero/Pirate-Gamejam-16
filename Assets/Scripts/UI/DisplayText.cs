using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.Mathematics;

public class DisplayText : MonoBehaviour
{
    public TextMeshProUGUI _textMeshPro;
    public string _textToDisplay;
    [SerializeField] private bool _displayOnStart = false;
    public float _fadeTime = 1;
    public float _displayTime = 2;
    private Coroutine _currentCoroutine;
    private Color _textColor;



    public virtual void Start()
    {
        _textColor = _textMeshPro.color;
        _textColor.a = 0;
        _textMeshPro.color = _textColor;

        if(!_displayOnStart) return;
        DoDisplayText(_textToDisplay);
    }


    public void DoDisplayText(string text) {
        _textMeshPro.text = text;
        if(_currentCoroutine != null) StopCoroutine(_currentCoroutine);
        StartCoroutine(Fade(0,1));
    }



    private IEnumerator Fade(float from, float to) {
        float lerp = 0;
        while(lerp <= 10) {
            yield return new WaitForSeconds(_fadeTime / 10);
            _textColor.a = math.lerp(from, to, lerp / 10);
            _textMeshPro.color = _textColor;
            lerp += 1;
        }

        yield return new WaitForSeconds(_displayTime);

        lerp = 0;

        while(lerp <= 10) {
            yield return new WaitForSeconds(_fadeTime / 10);
            _textColor.a = math.lerp(to, from, lerp / 10);
            _textMeshPro.color = _textColor;
            lerp += 1;
        }
    }
}
