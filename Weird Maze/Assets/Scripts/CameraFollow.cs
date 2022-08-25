using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    private Vector3 offset = new Vector3(4.5f, 6f, -9f);
    private float distancePerFollowerZ = -0.25f;
    private float distancePerFollowerY = 0.3f;

    private float yDist = 0;
    private float zDist = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    void LateUpdate()
    {
        yDist = distancePerFollowerY * (GameManager.gameManager.playersList.Count - 1);
        zDist = distancePerFollowerZ * (GameManager.gameManager.playersList.Count - 1);

        if (yDist > 3)
            yDist = 3;
        if (zDist < -2)
            zDist = -2;
        offset = new Vector3(4.5f, yDist + 6f, zDist - 9f);
        transform.position = new Vector3(GameManager.gameManager.currentPlayer.transform.position.x + offset.x,
                                         Mathf.Lerp(transform.position.y, GameManager.gameManager.currentPlayer.transform.position.y + offset.y, Time.deltaTime * 10),
                                         Mathf.Lerp(transform.position.z, GameManager.gameManager.currentPlayer.transform.position.z + offset.z, Time.deltaTime * 10));
    }
}
