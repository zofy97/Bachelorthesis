using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogin : MonoBehaviour
{
    public InputField userInput;
    public Text message;
    public Button startButton;
    public Button okButton;
    
    private string userName;
    private string deviceId;
    
    public void Awake()
    {
        userInput.gameObject.SetActive(true);
        deviceId = SystemInfo.deviceUniqueIdentifier;
        string currentDeviceId = PlayerPrefs.GetString("deviceId");
        if (currentDeviceId != null && currentDeviceId == deviceId)
        {
            message.text = "Willkommen zurück!";
            userInput.gameObject.SetActive(false);
            okButton.gameObject.SetActive(false);
            startButton.gameObject.SetActive(true);
            
        }
        else
        {
            okButton.gameObject.SetActive(true);
            startButton.gameObject.SetActive(false);
        }
    }

    public void UserLogin()
    {
        if (userInput.text != null && (userInput.text != null || userInput.text.Length != 0))
        {
            userName = userInput.text;
            SetUserData(userName);
            PlayerPrefs.SetString("deviceId", SystemInfo.deviceUniqueIdentifier);
            PlayerPrefs.SetInt("coinsCounter", 50);
            PlayerPrefs.Save();
        }
        else
        {
            SetUserData("Guest");
            PlayerPrefs.SetInt("coinsCounter", 50);
        }
    }

    private void SetUserData(string displayName)
    {
        new GameSparks.Api.Requests.RegistrationRequest()
            .SetDisplayName(displayName)
            .SetUserName(SystemInfo.deviceUniqueIdentifier)
            .SetPassword("abc")
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("Player registered");
                }
                else
                {
                    Debug.Log("Error");
                }
            });
    }

    private string GetUserData()
    {
        var displayName = "Guest";
        
        new GameSparks.Api.Requests.AccountDetailsRequest()
            .Send((response) =>
            {
                displayName = response.DisplayName;
                if (!response.HasErrors)
                {
                    Debug.Log("Player Name found");
                }
                else
                {
                    Debug.Log("Error");
                }
            });
        return displayName;
    }
}