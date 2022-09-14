using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    int triggerCount;
    int cubeName = 0;

    // Start is called before the first frame update
    void Start()
    {
        triggerCount = 0;
        cubeName = int.Parse(this.gameObject.name);
    }
    private void OnEnable()
    {
        this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Follower") || other.gameObject.CompareTag("Player"))
        {
            triggerCount++;

            if (triggerCount == cubeName)
            {
                this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                Debug.Log("triger false");
                triggerCount = 0;
            }
        }
    }

}
