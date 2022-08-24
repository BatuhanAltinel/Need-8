using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingRoad : MonoBehaviour
{
    private Vector2 firstFingerPos;
    private Vector2 lastFingerPos;
    private Touch touch;

    private bool isRotated = false;
    private bool distanceConfirmed = false;

    private int currentAngle = 0;

    private Quaternion _targetRot = Quaternion.identity;

    [SerializeField]
    private float _rotateSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        RotateRoad();
    }


    void RotateRoad()
    {
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                firstFingerPos = touch.position;
                isRotated = true;
            }
            if (touch.phase == TouchPhase.Moved && !distanceConfirmed)
            {
                lastFingerPos = touch.position + touch.deltaPosition;
                Debug.Log("Finger moving");
                float distance = firstFingerPos.x - lastFingerPos.x;
                if (lastFingerPos.x < firstFingerPos.x && isRotated)
                {
                    TurnLeft();
                    isRotated = false;
                    Debug.Log("Turning left");
                    if (Mathf.Abs(distance) > 10)
                    {
                        distanceConfirmed = true;
                    }
                }
                else if (lastFingerPos.x > firstFingerPos.x && isRotated)
                {
                    TurnRight();
                    isRotated = false;
                    Debug.Log("Turning right");
                    if (Mathf.Abs(distance) > 10)
                    {
                        distanceConfirmed = true;
                    }
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                isRotated = false;
                distanceConfirmed = false;
            }
        }
    }

    void TurnRight()
    {
        currentAngle -= 90;
        _targetRot = Quaternion.AngleAxis(currentAngle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRot, _rotateSpeed * Time.deltaTime);
    }

    void TurnLeft()
    {
        currentAngle += 90;
        _targetRot = Quaternion.AngleAxis(currentAngle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRot, _rotateSpeed * Time.deltaTime);
    }

}
