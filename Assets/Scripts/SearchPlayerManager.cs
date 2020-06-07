using GameSparks.Core;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class SearchPlayerManager : MonoBehaviour
{
    public Text searchResult;
    private string userName;

    void Awake()
    {
        GetPlayerInformation();
    }

    private void GetPlayerInformation()
    {
        new  GameSparks.Api.Requests.AccountDetailsRequest().Send((response) =>
        {
            if (!response.HasErrors)
            {
                print(response.DisplayName);
                userName = response.DisplayName;
                searchResult.text += "Name: " + response.DisplayName + "\n";

                print(response.Location);
                searchResult.text += "Standort: " + response.Location.City + "\n";
            }
            else
            {
                Debug.Log("Error Loading Player Data...");
            }
        });

        new GameSparks.Api.Requests.LogEventRequest().SetEventKey("LOAD_PLAYER").Send((response) =>
        {
            if (!response.HasErrors)
            {
                GSData data = response.ScriptData.GetGSData("player_Data");
                print("Player Coins: " + data.GetInt("playerCoins"));
                searchResult.text += "Münzen: " + data.GetInt("playerCoins") + "\n";
            }
            else
            {
                Debug.Log("Error Loading Player Data...");
            }
        });

        new GameSparks.Api.Requests.LeaderboardDataRequest()
            .SetLeaderboardShortCode("SCORE_LEADERBOARD")
            .SetEntryCount(100)
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    foreach (GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data)
                    {
                        if (entry.UserName == userName)
                        {
                            print(entry.Rank);
                            searchResult.text += "Rang: " + entry.Rank + "\n";
                            
                            print(entry.JSONData["SCORE"]);
                            searchResult.text += "Score: " + entry.JSONData["SCORE"] + "\n";
                        }
                    }
                }
                else
                {
                    Debug.Log("Error Retrieving Leaderboard Data...");
                }
            });
    }
}