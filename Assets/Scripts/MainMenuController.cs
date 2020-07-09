using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// script for settings button
public class MainMenuController : MonoBehaviour {

    [SerializeField]
    private Animator settingButtonAnim;
    private bool hidden;
    private bool canTouchSettingButtons;

    [SerializeField]
    private Button musicBtn;
    [SerializeField]
    private Sprite[] musicBtnSprite;

    private AudioSource clickSound;
    
    // on start music status is checked and suitable sprite for button selected
	void Start ()
    {
        if (AudioManager.singleton.isMusicOn)
        {
            AudioListener.volume = 1;
            musicBtn.image.sprite = musicBtnSprite[1];
        }
        else
        {
            AudioListener.volume = 0;
            musicBtn.image.sprite = musicBtnSprite[0];
        }

        clickSound = GetComponent<AudioSource>();
        canTouchSettingButtons = true;
        hidden = true;
	}

    /* when button is clicked slide in animation is played when button is hidden
     * otherwise slide out animation
     */
    IEnumerator DisableWhilePlayingSettingAnim()
    {
        if (canTouchSettingButtons)
        {
            if (hidden)
            {
                canTouchSettingButtons = false;
                settingButtonAnim.Play("SlideIn");
                hidden = false;
                yield return new WaitForSeconds(1.2f);
                canTouchSettingButtons = true;
            }
            else
            {
                canTouchSettingButtons = false;
                settingButtonAnim.Play("SlideOut");
                hidden = true;
                yield return new WaitForSeconds(1.2f);
                canTouchSettingButtons = true;
            }
        }
    }

    // when user clicks on setting button coroutine starts
    public void SettingBtn()
    {
        StartCoroutine(DisableWhilePlayingSettingAnim());
        clickSound.Play();
    }

    // turns music on or off when music button is clicked
    public void MusicButton()
    {
        clickSound.Play();

        if (AudioManager.singleton.isMusicOn)
        {
            AudioListener.volume = 0;
            musicBtn.image.sprite = musicBtnSprite[0];
            AudioManager.singleton.isMusicOn = false;
            AudioManager.singleton.Save();
        }
        else
        {
            AudioListener.volume = 1;
            musicBtn.image.sprite = musicBtnSprite[1];
            AudioManager.singleton.isMusicOn = true;
            AudioManager.singleton.Save();
        }
    }
}
