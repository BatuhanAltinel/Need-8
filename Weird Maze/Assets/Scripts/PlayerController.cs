using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2;
    private Animator anim;
    private Rigidbody myBody;
    
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        myBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        MoveDownQuick();
        FailCheck();
    }

    private void MoveForward()
    {
        if (!GameManager.gameManager.isGameOver)
        {
            if (this.gameObject == GameManager.gameManager.playersList[0])
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                anim.SetInteger("IsRunning", 1);
            }
            else
            {
                anim.SetInteger("IsRunning", 0);
            }
        }
        else
        {
            GameManager.gameManager.GameOver();
            anim.SetInteger("IsRunning", 0);
            anim.SetBool("IsCrush", true);
        }
    }


    private void MoveDownQuick()
    {
        float downSpeed = 100f;
        RaycastHit hit;
        Ray downRay = new Ray(this.transform.position, Vector3.down);

        if (Physics.Raycast(downRay, out hit))
        {
            Debug.Log(hit.transform + " hit çarpti.");
            if (hit.distance > 3)
            {
                Debug.Log("Mesafe doðru");
                myBody.AddForce(Vector3.down * Time.deltaTime * downSpeed, ForceMode.Impulse);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube") && !GameManager.gameManager.isGameOver)
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
            StartCoroutine(DestroyGameObject());
        }      
    }

    void FailCheck()
    {
        if (GameManager.gameManager.isGameOver)
        {
            anim.SetInteger("IsRunning", 0);
            anim.SetBool("IsCrush", true);
        }
        
    }

    IEnumerator DestroyGameObject()
    {
        yield return new WaitForSeconds(2f);
        if(!GameManager.gameManager.isGameOver)
            this.gameObject.SetActive(false);
    }

}

    

