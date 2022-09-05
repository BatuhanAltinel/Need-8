using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManager;
    public Button restartButton;
    public Button nextButton;

    public GameObject successPanel;
    public GameObject failedPanel;
   

    private void Awake()
    {
        if (uiManager == null)
        {
            uiManager = this;
        }
        else
            Destroy(gameObject);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        GameManager.gameManager.isGameStart = false;
        restartButton.gameObject.SetActive(false);
        failedPanel.SetActive(false);
    }

    public void NextLevelGame()
    {
        GameManager.gameManager.NextLevel();
        nextButton.gameObject.SetActive(false);
        successPanel.SetActive(false);
    }
    public void GameOverUI()
    {
        if (GameManager.gameManager.isGameOver && !GameManager.gameManager.isSuccess)
        {
            StartCoroutine(FailedPanelActive());
        }
    }
    public void SuccessUI()
    {
        if (GameManager.gameManager.isSuccess && !GameManager.gameManager.isGameOver)
        {
            StartCoroutine(SuccessPanelActive());
        }
    }

    IEnumerator FailedPanelActive()
    {
        yield return new WaitForSeconds(2f);
        failedPanel.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    IEnumerator SuccessPanelActive()
    {
        yield return new WaitForSeconds(2f);
        successPanel.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        
    }
}
