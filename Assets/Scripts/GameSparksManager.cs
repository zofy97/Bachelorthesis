using UnityEngine;

// class to make sure only one GameSparksManager object is active
public class GameSparksManager : MonoBehaviour
{
    private static GameSparksManager _instance = null;

    // on awake instance is created or old one destroyed
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}