using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    public GameObject[] levels = new GameObject[4];
    private GameObject currentLevel;
    private GameObject nextLevel;
    private GameObject entryLevel;
    private int levelNumber;


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
        entryLevel = GameObject.Find("Level entry");
        levelNumber = 0;
        currentLevel = levels[levelNumber];
    }

    public void NextLevel()
    {
        entryLevel.SetActive(false);
        Destroy(currentLevel);
        levelNumber++;
        LevelCheck();
        
        nextLevel = levels[levelNumber];
        nextLevel = Instantiate(nextLevel, nextLevel.transform.position, Quaternion.identity);
        currentLevel = nextLevel;
        
        GameManager.gameManager.isSuccess = false;
    }

    public void LevelCheck()
    {
        if (levelNumber >= levels.Length)
        {
            levelNumber = 0;
        }
        else if (levelNumber < 0)
            levelNumber = levels.Length - 1;
    }
    public void LoadCurrentLevel()
    {
        levelNumber--;
        GameManager.gameManager.isSuccess = false;
        GameManager.gameManager.isGameOver = false;
        NextLevel();
    }

}
