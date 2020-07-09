using UnityEngine;
using UnityEngine.UI;

/* script for player login
 * saves new player to database
 * or gets username from database for registered player
 */
public class PlayerLogin : MonoBehaviour
{
    public InputField userInput;
    public Text message;
    public Button startButton;
    public Button okButton;
    public GameObject playerName;
    
    private string userName;
    private string deviceId;
    
    // on awake check if deviceId of player is know or new
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
            playerName.gameObject.SetActive(true);
            GetUserData();
        }
        else
        {
            okButton.gameObject.SetActive(true);
            startButton.gameObject.SetActive(false);
            playerName.gameObject.SetActive(false);
        }
    }

    /* gets selected username of player and saves deviceId to player prefs
     * gives new player starting amount of coins
     */
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

    // saves new user to GameSparks database
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

    // gets username from GameSparks database
    private void GetUserData()
    {
        
        new GameSparks.Api.Requests.AccountDetailsRequest()
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("Player Name found");
                    playerName.GetComponentInChildren<Text>().text = response.DisplayName;
                }
                else
                {
                    Debug.Log("Error");
                    playerName.GetComponentInChildren<Text>().text = "Gast";
                }
            });
    }
}