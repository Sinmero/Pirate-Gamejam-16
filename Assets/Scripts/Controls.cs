using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public bool _isArrowControls = true;
    private static Controls _controls;
    public static Controls instance { get { return _controls; } }
    private static controlKeys _keys;
    public static controlKeys keys { get { return _keys; } }
    private static controlKeys _defaultKeys = new controlKeys(KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.Mouse0, KeyCode.R);
    private static controlKeys _customkeys = new controlKeys(KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.Mouse0, KeyCode.R);
    private static controlKeys _lockedControls = new controlKeys(KeyCode.None, KeyCode.None, KeyCode.None, KeyCode.None, KeyCode.None, KeyCode.None);



    private void Awake()
    {
        _keys = _defaultKeys;

        if (_controls == null) _controls = this;

        if (_isArrowControls) _keys = _customkeys;
    }



    public static void LockControls()
    {
        _keys = _lockedControls;
        SystemLogger.instance.Log($"Controls locked.", null);
    }



    public static void UnlockControls() {
        _keys = _customkeys;
        SystemLogger.instance.Log($"Controls unlocked.", null);
    }
}




public struct controlKeys
{
    public controlKeys(KeyCode up, KeyCode down, KeyCode left, KeyCode right, KeyCode shoot, KeyCode reload)
    {
        _up = up;
        _down = down;
        _left = left;
        _right = right;
        _shoot = shoot;
        _reload = reload;
    }

    public KeyCode _up;
    public KeyCode _down;
    public KeyCode _left;
    public KeyCode _right;
    public KeyCode _shoot;
    public KeyCode _reload;
}