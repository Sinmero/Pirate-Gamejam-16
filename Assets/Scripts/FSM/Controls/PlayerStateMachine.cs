using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public float _moveSpeed = 1;
    public float _accleleration = 2.5f;
    [SerializeField] private GameObject _playerBody;
    [SerializeField] private List<SpriteRenderer> _clothesList = new List<SpriteRenderer>();

    void Start()
    {
        State movement = new Movement(this);
        ChangeState(movement);
    }



    public override void Update()
    {
        base.Update();
        MouseClick();
    }



    private bool _isFlipped = false;
    public void FlipOutfit(bool flip)
    {

        if (flip == _isFlipped) return;
        _isFlipped = flip;
        // _spriteRenderer.flipX = flip;
        if (flipCoroutine != null) StopCoroutine(flipCoroutine); //prevent animations from overlapping
        if (!flip) flipCoroutine = StartCoroutine(flipAnimation(flipYVector.x, 1));
        if (flip) flipCoroutine = StartCoroutine(flipAnimation(flipYVector.x, -1));
    }


    private Coroutine flipCoroutine;
    private Vector3 flipYVector = Vector3.one;
    private float flipYTime = 0;
    private IEnumerator flipAnimation(float from, float to, float speed = 0.05f, float animStep = 0.25f)
    {

        if (flipYTime >= 1)
        {
            flipYTime = 0;
            StopCoroutine(flipCoroutine);
            yield break;
        }

        flipYTime += animStep;
        flipYVector.x = Mathf.Lerp(from, to, flipYTime);
        _playerBody.transform.localScale = flipYVector;

        yield return new WaitForSeconds(speed);

        flipCoroutine = StartCoroutine(flipAnimation(from, to));
    }



    public void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D[] hits = Physics2D.RaycastAll(ray, Vector2.zero);
            foreach (RaycastHit2D item in hits)
            {
                var iClickable = item.collider.gameObject.GetComponent<IClickable>();

                if (iClickable != null)
                {
                    iClickable.IOnClick();
                }
            }
        }
    }
}
