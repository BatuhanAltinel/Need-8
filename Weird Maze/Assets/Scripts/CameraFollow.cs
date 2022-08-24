using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(4.2f, 5.44f, -8);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = GameManager.gameManager.currentPlayer.transform.position + offset;
    }
}
