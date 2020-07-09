using UnityEngine;
using UnityEngine.UI;

// script to send and receive leaderboard information
public class LeaderboardManager : MonoBehaviour
{
    public Text playerName;
    public Text score;
    
    public void Awake() {
        GameSparks.Api.Messages.NewHighScoreMessage.Listener += HighScoreMessageHandler;
    }

    // on start call method to get leaderboard
    public void Start()
    {
        GetLeaderboard();
    }

    void HighScoreMessageHandler(GameSparks.Api.Messages.NewHighScoreMessage _message) {
        Debug.Log("NEW HIGH SCORE \n " + _message.LeaderboardName);
    }

    // get Leaderboard from GameSparks database
    public void GetLeaderboard()
    {
        Debug.Log ("Fetching Leaderboard Data...");

        new GameSparks.Api.Requests.LeaderboardDataRequest ()
            .SetLeaderboardShortCode ("SCORE_LEADERBOARD")
            .SetEntryCount(100)
            .Send ((response) => {

                if(!response.HasErrors)
                {
                    Debug.Log("Found Leaderboard Data...");
                    
                    // iterate through the leaderboard data
                    foreach(GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data) 
                    {
                        // get rank directly
                        int rank = (int)entry.Rank; 
                        playerName.text += entry.UserName + "\n";
                        // get the key, in order to get the score
                        score.text += entry.JSONData["SCORE"] + "\n"; 
                        Debug.Log("Rank:" + rank + " Name:" + playerName + " \n Score:" + score);
                        
                    }
                }
                else
                {
                    Debug.Log("Error Retrieving Leaderboard Data...");
                }

            });
    }

    // send new leaderboard information to GameSparks database
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