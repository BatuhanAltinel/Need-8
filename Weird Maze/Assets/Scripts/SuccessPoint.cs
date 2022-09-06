using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Follower"))
        {
            GameManager.gameManager.isSuccess = true;
            GameManager.gameManager.SuccessPlatformPoints();
            UIManager.uiManager.SuccessUI();
        }
    }
}
