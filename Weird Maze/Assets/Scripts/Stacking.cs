using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacking : MonoBehaviour
{
    private Vector3 _firstPlayerPos;
    private Vector3 _currentPlayerPos;
    private bool isTriggered = false;

    private void Start()
    {
        _firstPlayerPos = new Vector3(this.transform.position.x,this.transform.position.y + 1.3f,this.transform.position.z);
        Debug.Log(_firstPlayerPos);
        //_currentPlayerPos = new Vector3(transform.position.x, _firstPlayerPos.y + 1.3f, transform.position.z);
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
