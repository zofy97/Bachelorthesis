using UnityEngine;
using UnityEngine.SceneManagement;

public class GameContentManager : MonoBehaviour
{
    public void LineCalculationMode()
    {
        PlayerPrefs.SetString("operation", "lineCalculation");
        SceneManager.LoadScene("GameScene");
    }
    
    public void PointCalculationMode()
    {
        PlayerPrefs.SetString("operation", "pointCalculation");
        SceneManager.LoadScene("GameScene");
    }
    
    public void SmallerOrBiggerMode()
    {
        PlayerPrefs.SetString("operation", "smallerOrBigger");
        SceneManager.LoadScene("GameScene");
    }
    
    public void MixedMode()
    {
        PlayerPrefs.SetString("operation", "mixed");
        SceneManager.LoadScene("GameScene");
    }
}
