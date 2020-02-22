using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private Animator settingsButtonAnimator;

    private bool hiddenButtons;

    private bool canTouchButton;

    [SerializeField] private Button musicButton;
    [SerializeField] private Sprite[] musicButtonSprite;
    private AudioSource clickSound;

    void Start()
    {
        if (AudioManager.singleton.isMusicOn)
        {
            AudioListener.volume = 1;
            musicButton.image.sprite = musicButtonSprite[0];
        }
        else
        {
            AudioListener.volume = 0;
            musicButton.image.sprite = musicButtonSprite[1];
        }

        clickSound = GetComponent<AudioSource>();

        canTouchButton = true;
        hiddenButtons = true;
    }

    // make sure Animation is not disrupted
    IEnumerator DisableWhileAnimation()
    {
        if (canTouchButton)
        {
            if (hiddenButtons)
            {
                canTouchButton = false;
                settingsButtonAnimator.Play("SlideIn");
                hiddenButtons = false;
                yield return new WaitForSeconds(1.2f);
                canTouchButton = true;
            }
            else
            {
                canTouchButton = false;
                settingsButtonAnimator.Play("SlideOut");
                hiddenButtons = true;
                yield return new WaitForSeconds(1.2f);
                canTouchButton = true;
            }
        }
    }

    public void SettingButton()
    {
        StartCoroutine(DisableWhileAnimation());
        clickSound.Play();
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void MusicButton()
    {
        clickSound.Play();

        if (AudioManager.singleton.isMusicOn)
        {
            AudioListener.volume = 0;
            musicButton.image.sprite = musicButtonSprite[1];
            AudioManager.singleton.isMusicOn = false;
            AudioManager.singleton.Save();
        }
        else
        {
            AudioListener.volume = 1;
            musicButton.image.sprite = musicButtonSprite[0];
            AudioManager.singleton.isMusicOn = true;
            AudioManager.singleton.Save();
        }
    }
}