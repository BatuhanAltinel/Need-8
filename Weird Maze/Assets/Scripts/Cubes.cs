using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    int triggerCount;
    int cubeName = 0;
    private Rigidbody otherBody;
    float forceImpulse = 20f;

    // Start is called before the first frame update
    void Start()
    {
        triggerCount = 0;
        cubeName = int.Parse(this.gameObject.name);
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
            //otherBody = other.gameObject.GetComponent<Rigidbody>();
            //otherBody.GetComponent<Rigidbody>().isKinematic = false;
            //otherBody.AddForce(Vector3.back * forceImpulse * Time.deltaTime, ForceMode.Impulse);
            //StartCoroutine(FailedForce());
            //StartCoroutine(StopForce());
        }
    }
    IEnumerator FailedForce()
    {
        yield return new WaitForSeconds(0);
        otherBody.AddForce(Vector3.back * forceImpulse * Time.deltaTime, ForceMode.Impulse);
        forceImpulse += 20;
    }
    IEnumerator StopForce()
    {
        yield return new WaitForSeconds(3f);
        forceImpulse = 0;
        otherBody.GetComponent<Rigidbody>().isKinematic = true;
    }


}
