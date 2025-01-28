using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ChasePlayer : State
{
    public Rigidbody2D _playerRB;
    public SlimeAI _slimeAI;
    public ChasePlayer(StateMachine stateMachine) : base(stateMachine)
    {
        _stateMachine = stateMachine;
        _playerRB = Statics.instance._player.GetComponent<Rigidbody2D>();
        _slimeAI = _stateMachine.GetComponent<SlimeAI>();
    }



    private Vector3 _scale = new Vector3(1,1,1);



    public override void OnEnter()
    {
        base.OnEnter();
        Statics.instance.StartCoroutine(LateStart());
    }



    public override void OnUpdate()
    {
        base.OnUpdate();

        if(_playerRB != null) _slimeAI.rb.velocity = CalcPlayerDir(_playerRB) * _slimeAI._speed;

        if(_slimeAI.rb.velocityX < 0) { //flip towards moving direstion
            if(_scale.x < 0) return;
            _scale.x = -_scale.x;
            _slimeAI.transform.localScale = _scale;
        }
        if(_slimeAI.rb.velocityX > 0) {
            if(_scale.x > 0) return;
            _scale.x = -_scale.x;
            _slimeAI.transform.localScale = _scale;
        }
    }


    public Vector2 CalcPlayerDir(Rigidbody2D rb) {
        return (rb.transform.position - _slimeAI.transform.position).normalized;
    }



    public IEnumerator LateStart() {
        yield return new WaitForEndOfFrame();
        _scale = _slimeAI.transform.localScale;
    }
}
