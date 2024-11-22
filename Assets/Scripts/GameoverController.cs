using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverController : MonoBehaviour
{
    public GameObject gameoverParentUI;

    public TextMeshProUGUI gameoverTitle;
    public TextMeshProUGUI scoresText;
    public TextMeshProUGUI timerText;

    public BallController ballController;

    private void Awake()
    {
        gameoverTitle.text = string.Empty;
        timerText.text = string.Empty;
        gameoverParentUI.SetActive(false);
    }

    public void DisplayGameOver(string winner, int p1Score, int p2Score)
    {
        if (gameoverParentUI != null && gameoverTitle != null)
        {
            ballController.StopBallGradually();
            gameoverParentUI.SetActive(true);
            gameoverTitle.text = "GAME OVER! WINNER: " + winner;
            scoresText.text = $"P1: {p1Score} | P2: {p2Score}";

            StartCoroutine(DisplayTimer());
        }
        else
        {
            Debug.LogError("GameOverUI or GameOverText is not assigned in GameOverController.");
        }
    }

    private IEnumerator DisplayTimer()
    {
        if (timerText != null)
        {
            int timeCount = 5;

            for (int i = timeCount; i > 0; i--)
            {
                timerText.text = i.ToString();
                yield return new WaitForSeconds(1f);
            }

            timerText.text = "0";
        }

        SceneManager.LoadScene("MainMenu");
    }
}
