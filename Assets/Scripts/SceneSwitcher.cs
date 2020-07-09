using UnityEngine;
using UnityEngine.SceneManagement;

// script for loading scenes
public class SceneSwitcher : MonoBehaviour
{
    // load scene to is set in inspector
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
