using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if (GameManager.gameManager.triggerCount >= 2)
        {
            this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            Debug.Log("triger false");
        }
    }


}
