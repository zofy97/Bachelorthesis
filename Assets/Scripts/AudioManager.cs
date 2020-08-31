using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// script to control sound settings
public class AudioManager : MonoBehaviour
{
    public static AudioManager singleton;
    public bool isMusicOn;

    private AudioData audioData;
    private AudioSource backgroundMusic;

    // call methods once audio manager is active
    private void Awake()
    {
        CreateSingleton();
        InitializeVariables();
    }

    // get audio source component
    private void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
    }

    // stop background music when in game mode
    private void Update()
    {
        if (SceneManager.GetActiveScene().ToString() == "GameScene")
        {
            backgroundMusic.Stop();
        }
    }
    
    // make sure only one audio manager instance is active
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

    // initialize value for sound variables
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

    // save sound settings to sound settings
    public void Save()
    {
        if (audioData != null)
        {
            PlayerPrefs.SetString("isMusicOn", audioData.getIsMusicOn().ToString());
            PlayerPrefs.Save();
        }
    }

    // load sound settings from PlayerPrefs
    public void Load()
    {
        if (audioData != null)
        {
            PlayerPrefs.GetString("isMusicOn");
        }
    }
}

// audio data to set or get settings whether music is on or not
[Serializable]
class AudioData
{
    private bool isMusicOn;

    public void setIsMusicOn(bool isOn)
    {
       isMusicOn = isOn;
    }

    public bool getIsMusicOn()
    {
        return isMusicOn;
    }
}