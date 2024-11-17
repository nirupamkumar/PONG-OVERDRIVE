using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public Button play;
    public GameObject leaderBoardUI;
    public Button leaderBoard;
    public Button leaderboardBackButton;

    private void Awake()
    {
        if (mainMenu == null || leaderBoardUI == null)
        {
            Debug.LogError("MainMenuController: UI elements are not assigned in the Inspector.");
        }

        mainMenu.SetActive(true);
        leaderBoardUI.SetActive(false);
    }

    private void Start()
    {
        play.onClick.AddListener(Play);
        leaderBoard.onClick.AddListener(ShowLeaderboard);
        leaderboardBackButton.onClick.AddListener(HideLeaderboard);
    }

    /// <summary>
    /// Loads a random game scene when the Play button is clicked.
    /// </summary>
    private void Play()
    {
        int totalScenes = SceneManager.sceneCountInBuildSettings;
        if (totalScenes <= 1)
        {
            Debug.LogError("No game scenes found in Build Settings.");
            return;
        }

        int sceneIndex = Random.Range(1, totalScenes);
        SceneManager.LoadScene(sceneIndex);
    }

    private void ShowLeaderboard()
    {
        mainMenu.SetActive(false);
        leaderBoardUI.SetActive(true);
    }

    private void HideLeaderboard()
    {
        leaderBoardUI.SetActive(false);
        mainMenu.SetActive(true);
    }

    private void OnDestroy()
    {
        play.onClick.RemoveListener(Play);
        leaderBoard.onClick.RemoveListener(ShowLeaderboard);
        leaderboardBackButton.onClick.RemoveListener(HideLeaderboard);
    }
}
