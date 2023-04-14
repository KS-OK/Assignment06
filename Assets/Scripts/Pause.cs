using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Pause : MonoBehaviour
{
    public Text timeText;
    private bool isPaused = false;
    //public Button resumeButton;

    // Start is called before the first frame update
    void Start()
    {
        //timeText.text = "Time: " + DateTime.Now.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        if (isPaused)
        {
            timeText.text = "GAME PAUSED";
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        timeText.text = "GAME PAUSED";
        timeText.gameObject.SetActive(true);
        //resumeButton.gameObject.SetActive(true); // show the Resume button
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        //timeText.text = "Time: " + DateTime.Now.ToString();
        timeText.gameObject.SetActive(false);
        //resumeButton.gameObject.SetActive(false); // hide the Resume button while playing
    }
}
