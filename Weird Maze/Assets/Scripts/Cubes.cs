using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    int triggerCount;

    // Start is called before the first frame update
    void Start()
    {
        triggerCount = 0;   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Follower") || other.gameObject.CompareTag("Player"))
        {
            triggerCount++;
            if (triggerCount == 2)
            {
                this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                Debug.Log("triger false");
                triggerCount = 0;
            }

        }
    }


}
