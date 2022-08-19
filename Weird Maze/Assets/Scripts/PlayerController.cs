using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        if(this.gameObject == GameManager.gameManager.playersList[0])
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            anim.SetInteger("IsRunning", 1);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("2xCube"))
        {
            GameManager.gameManager.triggerCount++;
            anim.SetInteger("IsRunning", 0);
            anim.SetBool("IsCrush", true);
            GameManager.gameManager.FollowerRemoveFromList();
            Debug.Log(GameManager.gameManager.playersList.Count);
            

            StartCoroutine(DestroyGameObject());
        }
        IEnumerator DestroyGameObject()
        {
            yield return new WaitForSeconds(2f);

            this.gameObject.SetActive(false);
        }
    }

}

    

