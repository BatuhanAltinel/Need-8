using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    public GameObject[] levels = new GameObject[3];
    private GameObject currentLevel;
    private int levelNumber = 0;


    private void Awake()
    {
        if (levelManager == null)
        {
            levelManager = this;
        }
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = levels[levelNumber];
    }

    public void NextLevel()
    {
        if (GameManager.gameManager.isSuccess)
        {
            LevelCheck();
            if (levelNumber <= levels.Length-1)
            {
                currentLevel.SetActive(false);
                levelNumber++;
                currentLevel = levels[levelNumber];
                Instantiate(currentLevel, currentLevel.transform.position, Quaternion.identity);
                GameManager.gameManager.isSuccess = false;
            }
        }
    }

    public void LevelCheck()
    {
        if(levelNumber >= levels.Length - 1)
        {
            levelNumber = 0;
        }
    }
    public void LoadCurrentLevel()
    {
        currentLevel = levels[levelNumber];
        GameManager.gameManager.isSuccess = false;
        GameManager.gameManager.isGameOver = false;
    }
}
