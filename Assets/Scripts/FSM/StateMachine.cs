using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public Dictionary<string, State> _states = new Dictionary<string, State>();
    [HideInInspector] public State _currentState;

    public virtual void Update()
    {
        if (_currentState == null) return;
        _currentState.OnUpdate();
    }



    public void ChangeState(State state)
    {
        if (state == null)
        {
            SystemLogger.instance.Log($"No state was recieved!", this);
        }
        
        SystemLogger.instance.Log($"State was changes to {state}", this);
        _currentState?.OnExit();
        _currentState = state;
        _currentState.OnEnter();
    }
}
