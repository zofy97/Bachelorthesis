using System;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeGameController : MonoBehaviour
{
    // game objects in Unity
    public Text[] buttons;
    public GameObject gameOverDialog;
    public Text gameOverText;
    public GameObject restartButton;
    
    private string side;
    private int moves;

    // disable restart button and dialog window
    private void Start()
    {
        SetGameControllerReferences();
        
        side = "X";
        moves = 0;
        
        gameOverDialog.SetActive(false);
        restartButton.SetActive(false);
    }

    // get button and text references 
    private void SetGameControllerReferences()
    {
        for (var i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInParent<Space>().SetControllerReference(this);
        }
    }

    // get value of side
    public string GetSide()
    {
        return side;
    }

    // change sides
    public void SwitchSides()
    {
        if (side == "X")
            side = "O";
        else
            side = "X";
    }

    // determines which turns finish the game
    public void FinishTurn()
    {
        moves++;
        if (buttons[0].text == side && buttons[1].text == side && buttons[2].text == side)
            GameOver();
        else if (buttons[3].text == side && buttons[4].text == side && buttons[5].text == side)
            GameOver();
        else if (buttons[6].text == side && buttons[7].text == side && buttons[8].text == side)
            GameOver();
        else if (buttons[0].text == side && buttons[3].text == side && buttons[6].text == side)
            GameOver();
        else if (buttons[1].text == side && buttons[4].text == side && buttons[7].text == side)
            GameOver();
        else if (buttons[2].text == side && buttons[5].text == side && buttons[8].text == side)
            GameOver();
        else if (buttons[0].text == side && buttons[4].text == side && buttons[8].text == side)
            GameOver();
        else if (buttons[2].text == side && buttons[4].text == side && buttons[6].text == side)
            GameOver();
        if (moves >= 9)
        {
            gameOverDialog.SetActive(true);
            gameOverText.text = "Unentschieden!";
            restartButton.SetActive(true);
        }
        SwitchSides();
    }

    // when game is finished display messages and deactivate buttons
    void GameOver()
    {
        gameOverDialog.SetActive(true);
        gameOverText.text = side + " hat gewonnen!";
        restartButton.SetActive(true);
        for (var i = 0; i < buttons.Length; i++)
        {
            SetInteractable(false);
        }
    }

    // disable or enable buttons
    void SetInteractable(bool setting)
    {
        for (var i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInParent<Button>().interactable = setting;
        }
    }

    // resets and restarts game
    public void Restart()
    {
        side = "X";
        moves = 0;
        gameOverDialog.SetActive(false);
        SetInteractable(true);
        restartButton.SetActive(false);
        for (var i = 0; i < buttons.Length; i++)
        {
            buttons[i].text = "";
        }
    }
}