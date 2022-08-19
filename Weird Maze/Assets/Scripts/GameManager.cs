using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public GameObject playerPrefab;
    [HideInInspector]public GameObject playerInstantiate = null;
    [HideInInspector] public GameObject currentPlayer;
    [HideInInspector]public Vector3 spawnPoint = new Vector3();
    public int triggerCount = 0;
    public bool isFollow = true;

    [HideInInspector]public List<GameObject> playersList = new List<GameObject>();


    // Start is called before the first frame update
    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameManager);
        currentPlayer = GameObject.Find("Player");
        playersList.Add(currentPlayer);
    }
    private void Update()
    {
        if (playersList.Count > 1)
        {
            
        }
        
    }


    public void PlayerSpawn(Vector3 firstPos, int playerCount)
    {
        
        for (int i = 0; i < playerCount; i++)
        {
            if (i < 1)
            {
                spawnPoint = firstPos;
            }
            else
                spawnPoint.y += 1.3f;
                
            playerInstantiate = Instantiate(playerPrefab, spawnPoint, Quaternion.identity);
            FollowerAddToList(playerInstantiate);
            playerInstantiate.GetComponent<PlayerFollow>().UpdatePlayerPosition(playersList[0].transform, isFollow);
        }
    }

    public void FollowerAddToList(GameObject obj)
    {
        playersList.Add(obj);
    }
    public void FollowerRemoveFromList()
    {
        playersList.RemoveAt(0);
    }
    
}
