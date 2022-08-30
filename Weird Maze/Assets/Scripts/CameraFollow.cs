using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    private Vector3 offset = new Vector3(4.5f, 6f, -9f);
    private float distancePerFollowerZ = -0.25f;
    private float distancePerFollowerY = 0.3f;

    private bool failed = false;

    private float yDist = 0;
    private float zDist = 0;

    void LateUpdate()
    {
        if (!GameManager.gameManager.isGameOver)
        {
            yDist = distancePerFollowerY * (GameManager.gameManager.playersList.Count - 1);
            zDist = distancePerFollowerZ * (GameManager.gameManager.playersList.Count - 1);

            if (yDist > 3)
                yDist = 3;
            if (zDist < -2)
                zDist = -2;
            offset = new Vector3(4.5f, yDist + 6f, zDist - 9f);
            transform.position = new Vector3
                (GameManager.gameManager.currentPlayer.transform.position.x + offset.x,
                Mathf.Lerp(transform.position.y, GameManager.gameManager.currentPlayer.transform.position.y + offset.y, Time.deltaTime * 10),
                Mathf.Lerp(transform.position.z, GameManager.gameManager.currentPlayer.transform.position.z + offset.z, Time.deltaTime * 10));
        }
        else if (!failed && GameManager.gameManager.isGameOver)
        {
            
            failed = true;
        }
        FailCameraMovePosition();
        FailCameraSmoothRotation();
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
}
