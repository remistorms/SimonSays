using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Clock : MonoBehaviour {

   public  Manager_Difficulty difficulty;
    public TextMeshProUGUI timeText;
    public Image fillImage;
    public bool hasClockStarted = false;

    private void Start()
    {
        GLOBAL.instance.M_event.EVT_Replay_Game += ResetClock;
        GLOBAL.instance.M_event.EVT_Tutorial_Finished += StartClock;
        GLOBAL.instance.M_event.EVT_Game_Over += OnGameOver;
    }

    void ResetClock() {
        timeText.text = difficulty.gameTime.ToString("F0");
        hasClockStarted = false;
        fillImage.fillAmount = 1;
    }

    void OnGameOver() {
        //timeText.text = "--";
        ResetClock();
    }
    private void FixedUpdate()
    {
        if (hasClockStarted)
        {
            UpdateClockValue();
        }
        
    }
    void UpdateClockValue() {
        timeText.text = difficulty.timeLeft.ToString("F0");
        fillImage.fillAmount = Mathf.InverseLerp(0, difficulty.gameTime, difficulty.timeLeft);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartClock();
        }
    }

    void StartClock() {
        hasClockStarted = true;
    }
}
