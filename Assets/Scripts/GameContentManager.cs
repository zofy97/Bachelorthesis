using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameContentManager : MonoBehaviour
{
    public void AdditionMode()
    {
        PlayerPrefs.SetString("operation", "addition");
        SceneManager.LoadScene("GameScene");
    }
    
    public void SubtractionMode()
    {
        PlayerPrefs.SetString("operation", "subtraction");
        SceneManager.LoadScene("GameScene");
    }
    
    public void MultiplicationMode()
    {
        PlayerPrefs.SetString("operation", "multiplication");
        SceneManager.LoadScene("GameScene");
    }
    
    public void DivisionMode()
    {
        PlayerPrefs.SetString("operation", "division");
        SceneManager.LoadScene("GameScene");
    }
}
