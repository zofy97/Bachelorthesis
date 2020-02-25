using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogin : MonoBehaviour
{
    private string userName;
    public InputField userInput;
    public Button okButton;
    public Text message;
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
        }
    }

    public void UserLogin()
    {
        if (userInput.text != null && (userInput.text != null || userInput.text.Length != 0))
        {
            userName = userInput.text;
            SetUserData(userName);
            PlayerPrefs.SetString("deviceId", SystemInfo.deviceUniqueIdentifier);
            PlayerPrefs.Save();
        }
        else
        {
            SetUserData("Guest");
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