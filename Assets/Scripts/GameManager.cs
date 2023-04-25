using Newtonsoft.Json.Bson;
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
        //yield return new WaitForSecondsRealtime(5);
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

    public void DestroyGameObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }


}
