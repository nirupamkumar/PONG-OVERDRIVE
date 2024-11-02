using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public int totalScenes = 4;

    public void Play()
    {
        int sceneIndex = Random.Range(1, totalScenes);
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Application Quit");
    }
}
