using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public GameObject playerPrefab;
    [HideInInspector]public GameObject playerInstantiate;
    private GameObject currentPlayer;

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
    }
    private void Start()
    {
        currentPlayer = GameObject.Find("RealPlayer");
        playersList.Add(currentPlayer);
    }

    public void PlayerSpawn(Vector3 firstPos, Vector3 currentPos, int playerCount)
    {
        Vector3 spawnPoint = new Vector3();
        for (int i = 0; i < playerCount; i++)
        {
            if (i == 0)
            {
                spawnPoint = firstPos;
            }
            else if (i == 1)
            {
                spawnPoint = currentPos;
            }
            else if (i > 1)
            {
                currentPos.y += 1;
                spawnPoint = currentPos;
            }
                
            playerInstantiate = Instantiate(playerPrefab, spawnPoint, Quaternion.identity);
            playersList.Add(playerInstantiate);
            Debug.Log("first element of list : " + playersList[0].name);
            Debug.Log("player name :"+ playerInstantiate.name + "Player index" + playersList.IndexOf(playerInstantiate));
            playerInstantiate.GetComponent<PlayerFollow>().UpdatePlayerPosition(currentPlayer.transform, true);
            currentPlayer = playersList[i + 1];
        }
    }
}
