using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private float followSpeed;
    public static Stacking stacking;
    private void Start()
    {
        
    }
    public void UpdatePlayerPosition(Transform followedPlayer, bool isFollowStart)
    {
        StartCoroutine(StartFollowingToLastPlayerPosition(followedPlayer, isFollowStart));
        if (!isFollowStart)
        {
            StopCoroutine(StartFollowingToLastPlayerPosition(followedPlayer, isFollowStart));
        }
    }

    IEnumerator StartFollowingToLastPlayerPosition(Transform followedPlayer, bool isFollowStart)
    {

        if(isFollowStart)
        {
            yield return new WaitForEndOfFrame();
            transform.position = new Vector3(followedPlayer.transform.position.x,
                              transform.position.y,
                              Mathf.Lerp(transform.position.z, followedPlayer.position.z, followSpeed * Time.deltaTime));
        }
    }
}
