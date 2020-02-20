using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string SceneName;

    public string SceneNameBack;
    
    public void GoToScene()
    {
        Debug.Log(SceneName);
        SceneManager.LoadScene(SceneName);
    }

    public void GoBackToScene()
    {
        Debug.Log(SceneNameBack);
        SceneManager.LoadScene(SceneNameBack);
    }
}
