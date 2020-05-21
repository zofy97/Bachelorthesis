using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    private bool countDown;
    public Slider timerBar;
    public float countDownTime = 10.0f;
    public Text seconds;

    private void Awake()
    {
        countDown = false;
        timerBar.maxValue = countDownTime;
    }

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

    public void CountDownStart()
    {
        countDown = true;
    }
}
