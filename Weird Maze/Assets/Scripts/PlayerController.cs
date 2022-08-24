using System;
using System.Collections;
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
        }else
        {
            anim.SetInteger("IsRunning", 0);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("2xCube"))
        {
            if(GameManager.gameManager.playersList[0].name == "Player" )
            {
                Debug.Log("PLayer çarptý");
                GameManager.gameManager.BecomePlayer();
                GameManager.gameManager.FollowerRemoveFromList();
            }
            else
            {
                GameManager.gameManager.currentPlayer = GameManager.gameManager.playersList[0];
                GameManager.gameManager.BecomePlayer();
                GameManager.gameManager.FollowerRemoveFromList();
            }

            anim.SetInteger("IsRunning", 0);
            anim.SetBool("IsCrush", true);
           
            StartCoroutine(DestroyGameObject());
            
        }
        IEnumerator DestroyGameObject()
        {
            yield return new WaitForSeconds(2f);

            this.gameObject.SetActive(false);
        }
    }

}

    

