using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacking : MonoBehaviour
{
    private Vector3 _firstPlayerPos;
    private bool isTriggered = false;

    private void Update()
    {
        //_firstPlayerPos = new Vector3(this.transform.position.x,this.transform.position.y + 1.3f,this.transform.position.z);
        _firstPlayerPos = GameManager.gameManager.currentPlayer.transform.position + new Vector3(0,1.3f,0);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("4+Trigger"))
        {
            isTriggered = true;
            
            if (isTriggered)
            {
                isTriggered = false;
                GameManager.gameManager.PlayerSpawn(_firstPlayerPos, 4);
                _firstPlayerPos = GameManager.gameManager.spawnPoint;
                _firstPlayerPos.y += 1.3f;
               
            }
            
        }
    }
}
