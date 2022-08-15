using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private float followSpeed;

    public void UpdatePlayerPosition(Transform followedPlayer, bool isFollowStart)
    {
        StartCoroutine(StartFollowingToLastPlayerPosition(followedPlayer, isFollowStart));
    }

    IEnumerator StartFollowingToLastPlayerPosition(Transform followedPlayer, bool isFollowStart)
    {

        while (isFollowStart)
        {
            yield return new WaitForEndOfFrame();
            transform.position = new Vector3(followedPlayer.transform.position.x, transform.position.y,
                Mathf.Lerp(transform.position.z, followedPlayer.position.z, followSpeed * Time.deltaTime));
        }
    }
}
