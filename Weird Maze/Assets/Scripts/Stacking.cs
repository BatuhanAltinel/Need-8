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
        _firstPlayerPos = GetComponent<MeshRenderer>().bounds.max;
        _firstPlayerPos += new Vector3(0, 0.5f, 0);
        Debug.Log(_firstPlayerPos);
        _currentPlayerPos = new Vector3(transform.position.x, _firstPlayerPos.y + 1f, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            
            if (isTriggered)
            {
                isTriggered = false;
                GameManager.gameManager.PlayerSpawn(_firstPlayerPos, _currentPlayerPos, 4);
                _firstPlayerPos.y += _currentPlayerPos.y;
                _currentPlayerPos = new Vector3(transform.position.x, _firstPlayerPos.y + 1f, transform.position.z);
            }
            
        }
    }
}
