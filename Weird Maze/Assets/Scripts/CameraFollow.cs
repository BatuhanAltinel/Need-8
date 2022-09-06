using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    private Vector3 offset = new Vector3(2.9f, 6f, -9.5f);
    private float distancePerFollowerZ = -0.25f;
    private float distancePerFollowerY = 0.3f;

    Quaternion tempRot;

    private bool failed = false;
    private bool success = false;

    private float yDist = 0;
    private float zDist = 0;

    void LateUpdate()
    {
        if (!GameManager.gameManager.isGameOver && !GameManager.gameManager.isSuccess)
        {
            Camera.main.transform.rotation = Quaternion.Euler(10.2f, -12.7f, 0);
            yDist = distancePerFollowerY * (GameManager.gameManager.playersList.Count - 1);
            zDist = distancePerFollowerZ * (GameManager.gameManager.playersList.Count - 1);

            if (yDist > 4)
                yDist = 4;
            if (zDist < -3)
                zDist = -3;
            offset = new Vector3(2.9f, yDist + 6f, zDist - 9.5f);
            Camera.main.transform.position = new Vector3
                (GameManager.gameManager.currentPlayer.transform.position.x + offset.x,
                Mathf.Lerp(transform.position.y, GameManager.gameManager.currentPlayer.transform.position.y + offset.y, Time.deltaTime * 10),
                Mathf.Lerp(transform.position.z, GameManager.gameManager.currentPlayer.transform.position.z + offset.z, Time.deltaTime * 10));
            
        }
        else if (!failed && GameManager.gameManager.isGameOver)
        {
            failed = true;
        }
        else if (!success && GameManager.gameManager.isSuccess && !GameManager.gameManager.isGameOver)
            success = true;
        else if (!GameManager.gameManager.isSuccess && success)
        {
            Debug.Log("Success false olmalý.");
            success = false;
        }
            

        FailCameraMovePosition();
        FailCameraSmoothRotation();
        SuccessCameraSmoothRotation();
        SuccessCameraMovePosition();
    }

    void FailCameraMovePosition()
    {
        if (failed)
        {
            Vector3 failPos = new Vector3(13.5f + GameManager.gameManager.currentPlayer.transform.position.x,
                                      6.5f + GameManager.gameManager.currentPlayer.transform.position.y,
                                     -5.5f + GameManager.gameManager.currentPlayer.transform.position.z);

            transform.position = new Vector3
                    (Mathf.Lerp(transform.position.x, failPos.x, 1 * Time.deltaTime),
                    Mathf.Lerp(transform.position.y, failPos.y, 1 * Time.deltaTime),
                    Mathf.Lerp(transform.position.z, failPos.z, 1 * Time.deltaTime));
        }
        
    }

    void FailCameraSmoothRotation()
    {
        if (failed)
        {
            Quaternion failRot = Quaternion.Euler(17.6f + transform.rotation.x, -60f + transform.rotation.y, transform.rotation.z);
            transform.rotation = Quaternion.RotateTowards
                                    (this.transform.rotation, failRot, 100 * Time.deltaTime);
        }
    }

    void SuccessCameraMovePosition()
    {
        if (success)
        {
            Vector3 SuccessPos = new Vector3(19f, 17.7f, 179.4f);

            transform.position = new Vector3
                    (Mathf.Lerp(transform.position.x, SuccessPos.x, 3 * Time.deltaTime),
                    Mathf.Lerp(transform.position.y, SuccessPos.y, 3 * Time.deltaTime),
                    Mathf.Lerp(transform.position.z, SuccessPos.z, 3 * Time.deltaTime));
        }
    }

    void SuccessCameraSmoothRotation()
    {
        if (success)
        {
            Quaternion SuccessRot = Quaternion.Euler(14.6f + transform.rotation.x, -85f + transform.rotation.y,
                                    transform.rotation.z);
            transform.rotation = Quaternion.RotateTowards
                                    (this.transform.rotation, SuccessRot, 100 * Time.deltaTime);
        }
    }
}
