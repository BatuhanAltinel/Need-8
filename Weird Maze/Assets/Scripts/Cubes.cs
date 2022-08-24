using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    int triggerCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Follower") || other.gameObject.CompareTag("Player"))
        {
            triggerCount++;
            if (triggerCount == 1)
            {
                this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                Debug.Log("triger false");
                triggerCount = 0;
            }

        }
    }


}
