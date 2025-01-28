using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SetRandomColor : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private bool _setMaterialColor = false;
    [SerializeField] private bool _sameAsParentColor = false;
    [SerializeField] private List<Color32> _fixedColors = new List<Color32>();
    [HideInInspector] public Color32 _generatedColor;
    [SerializeField] private float 
    _rMin = 0, _rMax = 255f,
    _gMin = 0, _gMax = 255f,
    _bMin = 0, _bMax = 255;


    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_fixedColors.Count > 0)
        {
            SetFixedColor();
            return;
        }

        if(_sameAsParentColor) {
            SetAsParentColor();
            return;
        }
        RandomColor();
    }



    private void RandomColor()
    {
        byte r = (byte)UnityEngine.Random.Range(_rMin, _rMax);
        byte g = (byte)UnityEngine.Random.Range(_gMin, _gMax);
        byte b = (byte)UnityEngine.Random.Range(_bMin, _bMax);
        byte a = (byte)255;
        _generatedColor = new Color32(r, g, b, a);
        SetColor(_generatedColor);
    }



    private void SetFixedColor()
    {
        var index = math.floor(UnityEngine.Random.Range(0, _fixedColors.Count));
        SetColor(_fixedColors[(int)index]);
    }



    private void SetColor(Color32 color)
    {
        if(_setMaterialColor) {
            Material material = GetComponent<SpriteRenderer>().material;
            material.SetColor("_SpriteColor", color);
            return;
        }
        _spriteRenderer.color = color;
    }



    public void SetAsParentColor() {
        SetRandomColor setRandomColor = transform.parent.GetComponent<SetRandomColor>();
        if(setRandomColor == null) {
            SystemLogger.instance.Log($"{transform.name} parent does not have a SetRandomColor component", this);
            return;
        }

        SetColor(setRandomColor._generatedColor);
    }
}
