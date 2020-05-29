using System.Collections;
using System.Collections.Generic;
using GameSparks.Api.Requests;
using GameSparks.Core;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCounter : MonoBehaviour
{
    public Text coinsCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        coinsCounter.text = GetCoinsIntern().ToString();
    }

    public void UpdateCounterText()
    {
        coinsCounter.text = GetCoinsIntern().ToString();
    }

    public void SaveCoinsIntern(int coins)
    {
        PlayerPrefs.SetInt("coinsCounter", coins);
    }

    public int GetCoinsIntern()
    {
        return PlayerPrefs.GetInt("coinsCounter");
    }
    
    public void UpdateCoinsCounter(int coins)
    {
        new LogEventRequest().SetEventKey("SAVE_PLAYER").SetEventAttribute("COINS", coins).Send((response) => {
            if (!response.HasErrors) {
                Debug.Log("Player Saved To GameSparks...");
            } else {
                Debug.Log("Error Saving Player Data...");
            }
        });
    }

    public int GetCoinsFromPlayer()
    {
        new GameSparks.Api.Requests.LogEventRequest().SetEventKey("LOAD_PLAYER").Send((response) =>
        {
            if (!response.HasErrors)
            {
                Debug.Log("Received Player Data From GameSparks...");
                GSData data = response.ScriptData.GetGSData("player_Data");
                print("Player Coins: " + data.GetInt("playerCoins"));
            }
            else
            {
                Debug.Log("Error Loading Player Data...");
            }
        });
        return 0;
    }

}
