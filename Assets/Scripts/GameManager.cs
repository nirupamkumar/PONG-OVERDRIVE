using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject blockerPrefab;
    private bool hasBeenInstanctiated = false;

    //public GameObject[] powerUpPrefabs;
    public bool activePowerup = false;
    public GameObject slowEffectObj;
    public GameObject fastEffectObj;
    public GameObject magnetEffectObj;
    public GameObject sinusoidEffectObj;

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

        if (!hasBeenInstanctiated)
        {
            StartCoroutine(SpawnBlockerTime());
            hasBeenInstanctiated = true;
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

    private void SpawnPowerUp(bool spawnRandomPowers)
    {
        if (!activePowerup)
        {
            int randomPowerup = Random.Range(0, 4);
            GameObject powerupPrefab;

            switch (randomPowerup)
            {
                case 0:
                    powerupPrefab = slowEffectObj;
                    break;
                case 1:
                    powerupPrefab = fastEffectObj;
                    break;
                case 2:
                    powerupPrefab = magnetEffectObj;
                    break;
                case 3:
                    powerupPrefab = sinusoidEffectObj;
                    break;
                default:
                    powerupPrefab = null;
                    break;
            }

            if (powerupPrefab != null)
            {
                float spawnX = Random.Range(-4f, 4f);
                float spawmY = Random.Range(-3f, 3f);
                Vector3 spawnPosition = new Vector3(spawnX, spawmY, 0f);

                GameObject powerup = Instantiate(powerupPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    public void DestroyBlocker(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    public void SpawnBlockerAfterItDestroyed(bool spawnBlocker)
    {
        hasBeenInstanctiated = spawnBlocker;
    }
}
