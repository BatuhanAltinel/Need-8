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
    private void Start()
    {

    }
    private void Update()
    {
        GameOver();
        FollowTheFirst(playersList);
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
            //playerInstantiate.name = "clone " + i;
            FollowerAddToList(playerInstantiate);
        }
    }

    public void FollowTheFirst(List<GameObject> playersList)
    {
        currentPlayer = playersList[0];
        for (int i= 0; i < playersList.Count-1; i++)
        {
            playersList[i+1].GetComponent<PlayerFollow>().UpdatePlayerPosition(playersList[i].transform, true);
        }
        
    }

    public void FollowerAddToList(GameObject obj)
    {
        playersList.Add(obj);
    }

    public void FollowerRemoveFromList()
    {
        playersList.RemoveAt(0);
        Debug.Log("first player :" + playersList[0]);
        Debug.Log(playersList.Count);
        
    }

    public void GameOver()
    {
        if(playersList.Count < 1)
        {
            Debug.Log("GameOver");
            Time.timeScale = 0;
        }
        
    }
    public void BecomePlayer()
    {
        if (playersList.Count > 1)
        {
            playersList[1].GetComponent<PlayerFollow>().UpdatePlayerPosition(playersList[0].transform,false);
            currentPlayer = playersList[1];
            Debug.Log(playersList[1].name + "art�k takip etmiyor =>" + playersList[0].name);
            playersList[1].GetComponent<Stacking>().enabled = true;
        }
        
    }
    
}