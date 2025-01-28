using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotateTowardsCursor : MonoBehaviour
{
    private Vector2 estimatedTargetPos;
    // [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float rotationSpeed = 8f;
    [SerializeField] private bool canFlipOnRotation = true;
    private Vector3 flipYVector;
    private Action calcStall = () => {}, flipOnRotation = () => {};



    private void Start()
    {
        if (canFlipOnRotation)
        {
            flipOnRotation = () => {calcFlip();};
        }

        flipYVector = Vector3.one;
    }



    private void Update() {
        rotateTowardsCursor();
    }



    public void rotateTowardsCursor()
    {
        calcStall();
        flipOnRotation();
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        // Vector2 adjustedDirection = adjustDirection(direction);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        Debug.DrawRay(transform.position, direction, Color.red);
    }



    // public Vector2 adjustDirection(Vector2 vector)
    // {
    //     Vector2 dir = vector.normalized + (vector.normalized - rb.velocity.normalized);

    //     return dir.normalized * vector.magnitude;
    // }



    private bool isFlipped = false;
    private Coroutine flipCoroutine;
    private void calcFlip () {
        if (transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 270) {

            if(isFlipped) return;
            
            if(flipCoroutine != null) StopCoroutine(flipCoroutine); //prevent animations from overlapping

            flipCoroutine = StartCoroutine(flipAnimation(flipYVector.y, -1));
            isFlipped = true;
            return;
        }

        if(!isFlipped) return;
        if(flipCoroutine != null) StopCoroutine(flipCoroutine); //prevent animations from overlapping

        flipCoroutine = StartCoroutine(flipAnimation(flipYVector.y, 1));
        isFlipped = false;
    }



    private float flipYTime = 0;
    private IEnumerator flipAnimation(float from, float to, float speed = 0.05f, float animStep = 0.25f) {

        if(flipYTime >= 1) {
            flipYTime = 0;
            StopCoroutine(flipCoroutine);
            yield break;;
        }

        flipYTime += animStep;
        flipYVector.y = Mathf.Lerp(from, to, flipYTime);
        transform.localScale = flipYVector;

        yield return new WaitForSeconds(speed);

        flipCoroutine = StartCoroutine(flipAnimation(from, to));
    }
}
