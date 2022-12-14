using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingRoad : MonoBehaviour
{
    private Vector2 firstFingerPos;
    private Vector2 lastFingerPos;
    private Touch touch;

    private bool distanceConfirmed = false;

    private int currentAngle = 0;

    private Quaternion _targetRot = Quaternion.identity;

    [SerializeField]
    private float _rotateSpeed = 250f;

    // Update is called once per frame
    void Update()
    {
        RotateRoad();
        SmoothTurning();
    }


    void RotateRoad()
    {
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                firstFingerPos = touch.position;
            }
            if (touch.phase == TouchPhase.Moved && !distanceConfirmed)
            {
                lastFingerPos = touch.position + touch.deltaPosition;
                float distance = firstFingerPos.x - lastFingerPos.x;

                if (lastFingerPos.x < firstFingerPos.x)
                {
                    if (Mathf.Abs(distance) > 10)
                    {
                        currentAngle += 90;
                        distanceConfirmed = true;
                    }
                }
                else if (lastFingerPos.x > firstFingerPos.x)
                {
                    if (Mathf.Abs(distance) > 10)
                    {
                        currentAngle -= 90;
                        distanceConfirmed = true;
                    }
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                distanceConfirmed = false;
            }
        }
    }

    void SmoothTurning()
    {
        _targetRot = Quaternion.AngleAxis(currentAngle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRot, _rotateSpeed * Time.deltaTime);
    }
}
