using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public GameObject playerPrefab;
    [HideInInspector]public GameObject playerInstantiate = null;
    public GameObject currentPlayer;

    [HideInInspector]public Vector3 spawnPoint = new Vector3();

    [HideInInspector] public bool isGameOver = false;
    [HideInInspector] public bool isSuccess = false;
    [HideInInspector] public bool isGameStart = false;

    [HideInInspector] public List<GameObject> playersList = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
            Destroy(gameManager);
        playersList.Add(currentPlayer);
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
                spawnPoint.y += 1.4f;
                
            playerInstantiate = Instantiate(playerPrefab, spawnPoint, Quaternion.identity);
            FollowerAddToList(playerInstantiate);
        }
    }

    public void FollowTheFirst(List<GameObject> playersList)
    {
        if (!isGameOver && playersList.Count > 1)
        {
            currentPlayer = playersList[0];
            for (int i = 0; i < playersList.Count - 1; i++)
            {
                playersList[i + 1].GetComponent<PlayerFollow>().UpdatePlayerPosition(playersList[i].transform, true);
            }
        }
        else
            GameOver();
        
    }

    public void FollowerAddToList(GameObject obj)
    {
        playersList.Add(obj);
    }

    public void FollowerRemoveFromList()
    {
        if (!isGameOver && playersList.Count >= 1)
        {
            if (playersList.Count == 1)
            {
                playersList.Add(currentPlayer);
                isGameOver = true;
            }
            playersList.RemoveAt(0);
        }
            
    }

    public void GameOver()
    {
        if (isGameOver)
        {
            UIManager.uiManager.GameOverUI();
        }   
    }

    public void BecomePlayer()
    {
        if (playersList.Count > 1 && !isGameOver)
        {
            playersList[1].GetComponent<PlayerFollow>().UpdatePlayerPosition(playersList[0].transform, false);
            currentPlayer = playersList[1];
            playersList[1].GetComponent<Stacking>().enabled = true;
        }
    }

    public void NextLevel()
    {
        if (isSuccess)
        {
            LevelManager.levelManager.NextLevel();
            if (playersList.Count > 1)
            {
                for (int i = playersList.Count - 1; i > 0; i--)
                {
                    playersList[i].SetActive(false);
                    playersList.RemoveAt(i);
                    BecomePlayer();
                }
            }
            
            isGameOver = false;
            currentPlayer = playersList[0];
            currentPlayer.GetComponentInChildren<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            currentPlayer.transform.position = new Vector3(0, 1, -24.5f);
        }
    }
    public void LoadCurrentLevel()
    {

    }


}
