using GameSparks.Core;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class SearchPlayerManager : MonoBehaviour
{
    //public Text userInput;
    //public Button okButton;
    public Text searchResult;
    //public GameObject searchField;
    
    private string userName;

    void Awake()
    {
        /*if (userInput.text != null && (userInput.text != null || userInput.text.Length != 0))
        {
            userName = userInput.text;
            okButton.gameObject.SetActive(false);
            searchField.gameObject.SetActive(true);
            GetPlayerInformation();
        }*/
        
        GetPlayerInformation();
    }

    private void GetPlayerInformation()
    {
        new GameSparks.Api.Requests.LogEventRequest().SetEventKey("LOAD_PLAYER").Send((response) =>
        {
            if (!response.HasErrors)
            {
                Debug.Log("Received Player Data From GameSparks...");
                GSData data = response.ScriptData.GetGSData("player_Data");
                print("Player Coins: " + data.GetInt("playerCoins"));
                searchResult.text = "Player Coins: " + data.GetInt("playerCoins") + "\n";
                
                GSData dataName = response.ScriptData.GetGSData("player_Name");
                print("Player Name: " + data.GetString("playerName"));
                searchResult.text += "Player Name: " + data.GetInt("playerName") + "\n";
                
                GSData dataLastSeen = response.ScriptData.GetGSData("player_LastSeen");
                print("Player Last seen: " + data.GetLong("playerLastSeen"));
                searchResult.text += "Player Last seen: " + data.GetInt("playerLastSeen") + "\n";
                
                GSData dataCreationDate = response.ScriptData.GetGSData("player_CreationDate");
                print("Player Creation Date: " + data.GetDate("playerCreationDate"));
                searchResult.text += "Player Creation Date: " + data.GetInt("playerCreationDate");
            }
            else
            {
                Debug.Log("Error Loading Player Data...");
            }
        });
    }
}