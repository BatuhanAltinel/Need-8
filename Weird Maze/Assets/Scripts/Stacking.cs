using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacking : MonoBehaviour
{
    private Vector3 _firstPlayerPos;

    private void Update()
    {
        _firstPlayerPos = GameManager.gameManager.currentPlayer.transform.position + new Vector3(0,1.4f,0);
        if(GameManager.gameManager.playersList.Count > 1)
        {
            _firstPlayerPos += new Vector3(0, 1.4f * (float)(GameManager.gameManager.playersList.Count - 1), 0);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        int plusNumber = (int)char.GetNumericValue(other.gameObject.name[0]);
        if (other.CompareTag("4+Trigger"))
        {
             GameManager.gameManager.PlayerSpawn(_firstPlayerPos, plusNumber);
             Debug.Log("plus triggered");
             _firstPlayerPos = GameManager.gameManager.spawnPoint;
             _firstPlayerPos.y += 1.4f;
        }
    }
}
