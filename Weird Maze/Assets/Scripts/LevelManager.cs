using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    public GameObject[] levels = new GameObject[2];
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
            if (levelNumber <= 1)
            {
                currentLevel.SetActive(false);
                levelNumber++;
                currentLevel = levels[levelNumber];
                currentLevel.SetActive(true);
                GameManager.gameManager.isSuccess = false;
            }
            else
            {
                GameManager.gameManager.isGameOver = true;
                levelNumber = 0;
            }
        }
    }
}
