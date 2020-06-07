using UnityEngine;

// script to unlock games using player coins
public class GameUnlockManager : MonoBehaviour
{
    // dialog window for unlocking the game
    public GameObject dialog;
    // error dialog when player does not have enough coins
    public GameObject errorDialog;
    // coins counter in navigation panel
    public CoinsCounter coinsCounter;
    
    // unlocked symbols and buttons which disappear once game is unlocked
    public GameObject firstButton, firstShadow;
    public GameObject secondButton, secondShadow;
    public GameObject thirdButton, thirdShadow;
    public GameObject forthButton, forthShadow;

    // number of player coins
    private int coins;
    // number of game button that was clicked
    private int buttonNumber;

    // check which games are already unlocked
    private void Awake()
    {
        if (LoadUnlockedGames("gameOne"))
        {
            firstButton.gameObject.SetActive(false);
            firstShadow.gameObject.SetActive(false);
        }
        
        if (LoadUnlockedGames("gameTwo"))
        {
            secondButton.gameObject.SetActive(false);
            secondShadow.gameObject.SetActive(false);
        }
        
        if (LoadUnlockedGames("gameThree"))
        {
            thirdButton.gameObject.SetActive(false);
            thirdShadow.gameObject.SetActive(false);
        }
        
        if (LoadUnlockedGames("gameFour"))
        {
            forthButton.gameObject.SetActive(false);
            forthShadow.gameObject.SetActive(false);
        }
    }

    // dialog window is shown
    public void ShowDialog(int count)
    {
        dialog.gameObject.SetActive(true);
        coins = count;
    }

    // save number of button that was clicked to know which game is selected
    public void SaveNumber(int number)
    {
        buttonNumber = number;
    }

    // Dialog window is closed
    public void CloseDialog()
    {
        dialog.gameObject.SetActive(false);
    }

    /*
     * if player has enough coins, games gets unlocked and coinsCounter is updated
     * unlocked symbols are deactivated and number of unlocked game in saved in PlayerPrefs
     */
    public void UnlockGame()
    {
        var currentCoins = coinsCounter.GetCoinsIntern();
        if (currentCoins > coins)
        {
            var updatedCoins = currentCoins - coins;
            coinsCounter.SaveCoinsIntern(updatedCoins);
            coinsCounter.UpdateCoinsCounter(updatedCoins);
            CloseDialog();
            switch (buttonNumber)
            {
                case 1:
                    firstButton.gameObject.SetActive(false);
                    firstShadow.gameObject.SetActive(false);
                    SaveUnlockedGames("gameOne");
                    break;
                case 2:
                    secondButton.gameObject.SetActive(false);
                    secondShadow.gameObject.SetActive(false);
                    SaveUnlockedGames("gameTwo");
                    break;
                case 3:
                    thirdButton.gameObject.SetActive(false);
                    thirdShadow.gameObject.SetActive(false);
                    SaveUnlockedGames("gameThree");
                    break;
                case 4:
                    forthButton.gameObject.SetActive(false);
                    forthShadow.gameObject.SetActive(false);
                    SaveUnlockedGames("gameFour");
                    break;
            }
        }
        else
        {
            errorDialog.gameObject.SetActive(true);
            CloseDialog();
        }
    }

    // Save unlocked games in PlayerPrefs
    private void SaveUnlockedGames(string gameNumber)
    {
        PlayerPrefs.SetString(gameNumber, "unlocked");
    }

    // Load unlocked games from PlayerPrefs
    private bool LoadUnlockedGames(string gameNumber)
    {
        return PlayerPrefs.GetString(gameNumber) == "unlocked";
    }
}