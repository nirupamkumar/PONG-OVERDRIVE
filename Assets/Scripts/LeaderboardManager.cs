using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public GameObject entryTemplate;
    public Transform leaderboardPanel;

    public List<LeaderBoardEntry> entries = new List<LeaderBoardEntry>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
