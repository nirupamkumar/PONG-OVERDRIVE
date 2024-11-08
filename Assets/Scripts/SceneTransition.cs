using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public int totalScenes = 4;
    public GameObject leaderBoardUI;

    private void Awake()
    {
        leaderBoardUI.SetActive(false);
    }

    public void Play()
    {
        int sceneIndex = Random.Range(1, totalScenes);
        SceneManager.LoadScene(sceneIndex);
    }

    public void LeaderBoard()
    {
        leaderBoardUI.SetActive(true);
    }
}
