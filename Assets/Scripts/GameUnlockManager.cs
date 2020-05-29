using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameUnlockManager : MonoBehaviour
{
    public GameObject dialog;
    public GameObject errorDialog;
    public CoinsCounter coinsCounter;
    public GameObject firstButton, firstShadow;
    public GameObject secondButton, secondShadow;
    public GameObject thirdButton, thirdShadow;
    public GameObject forthButton, forthShadow;
    
    private int coins;
    private int buttonNumber;
    
    public void ShowDialog(int count)
    {
        dialog.gameObject.SetActive(true);
        coins = count;
    }

    public void SaveNumber(int number)
    {
        buttonNumber = number;
    }

    public void CloseDialog()
    {
        dialog.gameObject.SetActive(false);
    }

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
                    break;
                case 2:
                    secondButton.gameObject.SetActive(false);
                    secondShadow.gameObject.SetActive(false);
                    break;
                case 3:
                    thirdButton.gameObject.SetActive(false);
                    thirdShadow.gameObject.SetActive(false);
                    break;
                case 4:
                    forthButton.gameObject.SetActive(false);
                    forthShadow.gameObject.SetActive(false);
                    break;
            }
        }
        else
        {
            errorDialog.gameObject.SetActive(true);
            CloseDialog();
        }
    }
}