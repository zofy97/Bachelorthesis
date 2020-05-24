using System;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    //public Text entryCount, outputData;
    public Text playerName;
    public Text score;
    
    public void Awake() {
        GameSparks.Api.Messages.NewHighScoreMessage.Listener += HighScoreMessageHandler;
    }

    public void Start()
    {
        GetLeaderboard();
    }

    void HighScoreMessageHandler(GameSparks.Api.Messages.NewHighScoreMessage _message) {
        Debug.Log("NEW HIGH SCORE \n " + _message.LeaderboardName);
    }
    
    public void GetLeaderboardInfos()
    {
        new GameSparks.Api.Requests.LeaderboardDataRequest().SetLeaderboardShortCode("SCORE_LEADERBOARD").SetEntryCount(100).Send((response) => {
            if (!response.HasErrors) {
                Debug.Log("Found Leaderboard Data...");
                foreach(GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data) {
                    int rank = (int) entry.Rank;
                    playerName.text = entry.UserName;
                    score.text = entry.JSONData["SCORE"].ToString();
                    Debug.Log("Rank:" + rank + " Name:" + playerName + " \n Score:" + score);
                }
            } else {
                Debug.Log("Error Retrieving Leaderboard Data...");
            }
        });
    }
    
    public void GetLeaderboard()
    {
        Debug.Log ("Fetching Leaderboard Data...");

        new GameSparks.Api.Requests.LeaderboardDataRequest ()
            .SetLeaderboardShortCode ("SCORE_LEADERBOARD")
            .SetEntryCount(100) // we need to parse this text input, since the entry count only takes long
            .Send ((response) => {

                if(!response.HasErrors)
                {
                    Debug.Log("Found Leaderboard Data...");
                    //outputData.text = System.String.Empty; // first clear all the data from the output
                    foreach(GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data) // iterate through the leaderboard data
                    {
                        int rank = (int)entry.Rank; // we can get the rank directly
                        string player = entry.UserName;
                        string count = entry.JSONData["SCORE"].ToString(); // we need to get the key, in order to get the score
                        //outputData.text += rank+"   Name: "+playerName+"        Score:"+score +"\n"; // addd the score to the output text
                        
                        Debug.Log("Rank:" + rank + " Name:" + player + " \n Score:" + count);
                        
                    }
                }
                else
                {
                    Debug.Log("Error Retrieving Leaderboard Data...");
                }

            });
    }

    public void SendLeaderboardInfos(int scoreCount)
    {
        new GameSparks.Api.Requests.LogEventRequest().SetEventKey("SUBMIT_SCORE").SetEventAttribute("SCORE", scoreCount).Send(
            (response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("Score Posted Successfully...");
                }
                else
                {
                    Debug.Log("Error Posting Score...");
                }
            });
    }
}