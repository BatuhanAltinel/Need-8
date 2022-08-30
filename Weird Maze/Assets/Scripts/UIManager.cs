using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button restartButton;
    public GameObject failedPanel;
    
    private void Update()
    {
        GameOverUI();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        restartButton.gameObject.SetActive(false);
        failedPanel.SetActive(false);
    }
    public void GameOverUI()
    {
        if (GameManager.gameManager.isGameOver)
        {
            StartCoroutine(FailedPanelActive());
        }
    }
    public void SuccessUI()
    {

    }

    IEnumerator FailedPanelActive()
    {
        yield return new WaitForSeconds(2f);
        failedPanel.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
}
