using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager singleton;

    private AudioData audioData;

    public bool isMusicOn;

    private AudioSource backgroundMusic;

    private void Awake()
    {
        CreateSingleton();
        InitializeVariables();
    }

    void CreateSingleton()
    {
        if (singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().ToString() == "GameScene")
        {
            backgroundMusic.Stop();
        }
    }

    void InitializeVariables()
    {
        Load();

        if (audioData == null)
        {
            isMusicOn = true;

            audioData = new AudioData();

            audioData.setIsMusicOn(isMusicOn);

            Save();

            Load();
        }
        else
        {
            isMusicOn = audioData.getIsMusicOn();
        }
    }

    public void Save()
    {
        if (audioData != null)
        {
            PlayerPrefs.SetString("isMusicOn", audioData.getIsMusicOn().ToString());
        }
    }

    public void Load()
    {
        if (audioData != null)
        {
            PlayerPrefs.GetString("isMusicOn");
        }
    }
}

[Serializable]
class AudioData
{
    private bool isMusicOn;

    public void setIsMusicOn(bool isMusicOn)
    {
        this.isMusicOn = isMusicOn;
    }

    public bool getIsMusicOn()
    {
        return isMusicOn;
    }
}