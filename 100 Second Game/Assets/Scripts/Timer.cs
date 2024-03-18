using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 100;
    public bool timerIsRunning = false;
    public bool hasWon;

    public GameObject winScreen;
    public TMP_Text winText;
    public GameObject winAnimationObject;

    public Slider sliderTimer;
    public TMP_Text timeText;

    public Color green;

    public AudioSource winAudio;
    public Animator winAnimation;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        hasWon = false;

        sliderTimer.maxValue = timeRemaining;
        sliderTimer.value = timeRemaining;

        Time.timeScale = 1;
    }
    void Update()
    {
        //float time = timeRemaining - Time.deltaTime;

        //int minutes = Mathf.FloorToInt(time / 60);
        //int seconds = Mathf.FloorToInt(time - minutes * 60f);

        //string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        //if (time < 0)
        //{
        //    timerIsRunning = false;
        //    
        //}
        //if (timerIsRunning)
        //{
        //    
        //    timeText.text = textTime;
        //}

        //check to see if timer is running and end the game when the timer ends
        if (timerIsRunning)
        {
            DisplayTime(timeRemaining);

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                sliderTimer.value = timeRemaining;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                hasWon = true;

                
                winText.text = "Win!!!";
                winText.color = green;
                winScreen.SetActive(true);
                winAnimationObject.SetActive(true);
                winAnimation.SetTrigger("heaven1");
                winAudio.Play();
                //Time.timeScale = 0;
            }
        }
    }

    // display the timer as each second ticks down
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
