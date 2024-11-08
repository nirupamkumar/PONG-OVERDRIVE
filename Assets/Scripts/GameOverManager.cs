using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public LeaderboardManager leaderBoardmanager;

    public void OnGameOver(int gameNumber, string boardType, int p1Score, int p2Score, string winner)
    {
        LeaderBoardEntry newEntry = new LeaderBoardEntry();

        newEntry.gameNumber = "Game" + gameNumber;
        newEntry.boardType = boardType;
        newEntry.dateTime = System.DateTime.Now.ToString("MM/dd/yyyy HH:mm");
        newEntry.playerScores = $"P1 {p1Score} | P2 { p2Score}";
        newEntry.winner = winner;

        // leaderboardManager.AddEntry(newEntry);
    }
}
