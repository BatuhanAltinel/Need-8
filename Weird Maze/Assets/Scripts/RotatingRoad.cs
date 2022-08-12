using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingRoad : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 120f;

    private Vector2 firstFingerPos;
    private Vector2 lastFingerPos;
    private Touch touch;
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        RoadRotation();
        if(Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                firstFingerPos = touch.position;
            }
            if(touch.phase == TouchPhase.Moved)
            {
                lastFingerPos = touch.position + touch.deltaPosition;
                Debug.Log("Finger moving");

                if(lastFingerPos.x < firstFingerPos.x)
                {
                    transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
                    if (transform.rotation.z >= 90)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, -90);
                    }
                    Debug.Log("Turning left");
                }else if(lastFingerPos.x > firstFingerPos.x)
                {
                    transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
                    if (transform.rotation.z >= 90)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 90);
                    }
                    Debug.Log("Turning right");
                }
            }
        }
    }

    private void RoadRotation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
            if(transform.rotation.z >= 90)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
        }else if(Input.GetKey(KeyCode.S))
        {
            transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
            if (transform.rotation.z <= -90)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
        }
        
    }
}
