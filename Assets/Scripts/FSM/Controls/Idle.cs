using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Movement
{
    public Idle(StateMachine stateMachine): base(stateMachine) {
        _stateMachine = stateMachine;
    }
}
