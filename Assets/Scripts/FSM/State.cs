using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public abstract class State
{
    [HideInInspector] public StateMachine _stateMachine;

    public State(StateMachine stateMachine) {
        _stateMachine = stateMachine;
    }


    public virtual void OnEnter()
    {

    }

    public virtual void OnExit()
    {

    }

    public virtual void OnUpdate()
    {

    }
}
