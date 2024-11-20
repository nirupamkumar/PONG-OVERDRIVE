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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
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
        //game over display script
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
