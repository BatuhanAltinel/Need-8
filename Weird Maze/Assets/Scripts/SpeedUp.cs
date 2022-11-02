using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class SpeedUp : MonoBehaviour
{
    [SerializeField] private GameObject[] speedTiles;


    void Start()
    {
        SpeedUpLights();
    }

    void SpeedUpLights()
    {
        StartCoroutine(SpeedUpLightRoutine());
    }

    IEnumerator SpeedUpLightRoutine()
    {
        Material _material;
        float colorChangeTime = 0.68f;
        float delayTime = 0.1f;

        foreach (GameObject tile in speedTiles)
        {
            yield return new WaitForSeconds(delayTime);
            _material = tile.GetComponent<Renderer>().material;
            _material.DOColor(Color.green,colorChangeTime).SetEase(Ease.InOutQuad).SetLoops(-1,LoopType.Yoyo);
            delayTime += 0.02f;    
        }
    }
}
