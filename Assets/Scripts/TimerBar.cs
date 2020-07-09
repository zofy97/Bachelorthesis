using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// script for timer during math game
public class TimerBar : MonoBehaviour
{
    private bool countDown;
    public Slider timerBar;
    // amount of seconds for game
    public float countDownTime = 10.0f;
    public Text seconds;

    // on awake set timer to selected seconds but countdown is not yet started
    private void Awake()
    {
        countDown = false;
        timerBar.maxValue = countDownTime;
    }

    /* on update seconds are counted down
     * once seconds are over previous scene is loaded
     */
    private void Update()
    {
        if (countDown)
        {
            countDownTime -= Time.deltaTime;
            timerBar.value = countDownTime;
            seconds.text = Mathf.RoundToInt(countDownTime).ToString();

            if (countDownTime < 0)
                SceneManager.LoadScene("TaskOverviewScene");
        }
    }

    // called once countdown starts
    public void CountDownStart()
    {
        countDown = true;
    }
}
