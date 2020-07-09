using UnityEngine;
using UnityEngine.UI;

// script to set text of selected button and disable interactability
public class Space : MonoBehaviour
{
    public Button button;
    public Text buttonText;

    private TicTacToeGameController ticTacToeGameController;

    // set reference for controller
    public void SetControllerReference(TicTacToeGameController controller)
    {
        ticTacToeGameController = controller;
    }

    // set button text and interactability
    public void SetSpace()
    {
        buttonText.text = ticTacToeGameController.GetSide();
        button.interactable = false;
        ticTacToeGameController.FinishTurn();
    }
}