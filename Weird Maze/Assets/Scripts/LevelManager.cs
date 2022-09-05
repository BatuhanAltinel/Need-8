using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    public GameObject[] levels = new GameObject[3];
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
        Debug.Log(currentLevel.name + " destroyed");
        levelNumber++;
        LevelCheck();
        
        nextLevel = levels[levelNumber];
        Debug.Log("Next level is " + nextLevel.name);
        //nextLevel.SetActive(true);
        nextLevel = Instantiate(nextLevel, nextLevel.transform.position, Quaternion.identity);
        currentLevel = nextLevel;
        
        GameManager.gameManager.isSuccess = false;
    }

    public void LevelCheck()
    {
        if(levelNumber >= levels.Length)
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
