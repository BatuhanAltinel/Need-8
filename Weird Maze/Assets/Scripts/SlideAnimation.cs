using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideAnimation : MonoBehaviour
{
    private Animator anim;
    private Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gameManager.isGameStart)
        {
            this.gameObject.SetActive(true);
            anim.SetBool("IsGameStart", false);
        }
        if (Input.touchCount > 0)
        {
            if(touch.phase == TouchPhase.Began)
            {
                anim.SetBool("IsGameStart", true);
                this.gameObject.SetActive(false);
                GameManager.gameManager.isGameStart = true;
            }
            
        }
        
    }
}
