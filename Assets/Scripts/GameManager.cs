using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject blockerPrefab;
    private bool activeBlocker = false;

    public GameObject[] powerUpPrefabs;
    public bool activePowerup = false;

    public ScoreController player1ScoreController;
    public ScoreController player2ScoreController;

    public GameoverController gameoverController;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (!activeBlocker)
        {
            StartCoroutine(SpawnBlockerTime());
            activeBlocker = true;
        }

        if (!activePowerup)
        {
            StartCoroutine(SpawnPowerTime());
            activePowerup = true;
        }
    }

    public void RegisterPlayer(ScoreController scoreController)
    {
        if (scoreController.playerIdentifier == "P1")
        {
            player1ScoreController = scoreController;
        }
        else if (scoreController.playerIdentifier == "P2")
        {
            player2ScoreController = scoreController;
        }
    }

    IEnumerator SpawnBlockerTime()
    {
        yield return new WaitForSecondsRealtime(15f);
        SpawnBlocker();
    }

    void SpawnBlocker()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float y = Random.Range(-3.0f, 3.0f);
        Instantiate(blockerPrefab, new Vector3(x, y, 0), Quaternion.identity);
    }

    public void SpawnBlockerAfterItDestroyed(bool spawnBlocker)
    {
        activeBlocker = spawnBlocker;
    }

    IEnumerator SpawnPowerTime()
    {
        yield return new WaitForSecondsRealtime(Random.Range(0f, 20f));
        SpawnPowerUp();  
    }
         
    public void SpawnPowerUp()
    {
        int randomPowerup = Random.Range(0, powerUpPrefabs.Length);
        GameObject powerupPrefabGO = powerUpPrefabs[randomPowerup]; 

        float spawnX = Random.Range(-4f, 4f);
        float spawmY = Random.Range(-3f, 3f);
        Vector3 spawnPosition = new Vector3(spawnX, spawmY, 0f);
        GameObject powerup = Instantiate(powerupPrefabGO, spawnPosition, Quaternion.identity);
    }

    public void SpawnPowerupsAfterDestroyed(bool spawnPowerups)
    {
        activePowerup = spawnPowerups;
    }

    public void GameOver(string winneridentifier)
    {
        int p1score = player1ScoreController.GetScore();
        int p2score = player2ScoreController.GetScore();

        gameoverController.DisplayGameOver(winneridentifier, p1score, p2score);
    }

    public void DestroyGameObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
