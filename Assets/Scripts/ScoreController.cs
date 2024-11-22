using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public string playerIdentifier;
    private int maxScore = 5;
    private int score = 0;
    private bool gameover = false;

    private void Start()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.RegisterPlayer(this);
        }
        else
        {
            Debug.LogError("GameManager instance in ScoreController not found.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!gameover && collision.gameObject.tag == "Ball")
        {
            score++;
            scoreText.text = score.ToString();

            if (score >= maxScore)
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        gameover = true;

        if (GameManager.instance != null)
        {
            GameManager.instance.GameOver(playerIdentifier);
        }
        else
        {
            Debug.LogError("GameManager instance in ScoreController not found.");
        }
    }

    public string GetPlayerIdentifier()
    {
        return playerIdentifier;
    }

    public int GetScore()
    {
        return score;
    }
}
