using UnityEngine;
using UnityEngine.SceneManagement;

// class to save selected operation mode to player prefs 
public class GameContentManager : MonoBehaviour
{
    // line calculation mode was selected
    public void LineCalculationMode()
    {
        PlayerPrefs.SetString("operation", "lineCalculation");
        SceneManager.LoadScene("GameScene");
    }
    
    // point calculation mode was selected
    public void PointCalculationMode()
    {
        PlayerPrefs.SetString("operation", "pointCalculation");
        SceneManager.LoadScene("GameScene");
    }
    
    // smaller or bigger mode was selected
    public void SmallerOrBiggerMode()
    {
        PlayerPrefs.SetString("operation", "smallerOrBigger");
        SceneManager.LoadScene("GameScene");
    }
    
    // mixed mode was selected
    public void MixedMode()
    {
        PlayerPrefs.SetString("operation", "mixed");
        SceneManager.LoadScene("GameScene");
    }
}
