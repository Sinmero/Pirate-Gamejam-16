using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : Movement
{
    public Moving(StateMachine stateMachine): base(stateMachine) {
        _stateMachine = stateMachine;
    }
}
