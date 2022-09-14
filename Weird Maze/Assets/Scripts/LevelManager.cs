using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    public GameObject[] levels = new GameObject[5];
    private GameObject currentLevel;
    private GameObject nextLevel;
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
        levelNumber = 0;
        currentLevel = levels[levelNumber];
        currentLevel.SetActive(true);
    }

    public void NextLevel()
    {
        currentLevel.SetActive(false);
        LevelCheck();

        nextLevel = levels[levelNumber];
        //nextLevel = Instantiate(nextLevel, nextLevel.transform.position, Quaternion.identity);
        nextLevel.SetActive(true);

        currentLevel = nextLevel;
        GameManager.gameManager.isSuccess = false;
    }

    public void LevelCheck()
    {
        levelNumber++;
        if (levelNumber >= levels.Length)
        {
            levelNumber = 0;
        }
    }
    
}
