using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Difficulty : Manager {

    public static Manager_Difficulty instance;


    [Header("Game Variables")]
    public int playerScore;
    public float gameTime;
    public float timeLeft;
    public int difficultyLevel;
    public bool hasTimerStarted;

    [Header("Sequence Variables")]
    public float minSequenceValue = 3.0f;
    public float maxSequenceValue = 8.0f;
    public float currentSequenceValue;
    public float sequencePercentToAdd = 0.0f;
    public float sequencePercent = 0.0f;
    public float sequenceSteps = 10.0f;

    [Header("Display Time Variables")]
    public float minDisplayTime = 1.0f;
    public float maxDisplayTime = 0.2f;
    public float currentDisplayTime;
    public float displayTimePercentToAdd = 0.0f;
    public float displayTimePercent = 0.0f;
    public float displayTimeSteps = 20.0f;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        ResetDifficulty();
        GLOBAL.instance.M_event.EVT_Sequence_Completed += UpDifficulty;
        GLOBAL.instance.M_event.EVT_Tutorial_Finished += StartTimer;
        GLOBAL.instance.M_event.EVT_Replay_Game += ResetDifficulty;
    }

    void ResetDifficulty() {
        //Initialize values
        timeLeft = gameTime;
        hasTimerStarted = false;
        playerScore = 0;
        difficultyLevel = 0;
        //Initialize sequence variables
        currentSequenceValue = minSequenceValue;
        sequencePercent = 0;
        sequencePercentToAdd = 1 / sequenceSteps;
        //Initialize display variables
        currentDisplayTime = maxDisplayTime;
        displayTimePercent = 0;
        displayTimePercentToAdd = 1 / displayTimeSteps;

    }

    public void StartTimer() {
        hasTimerStarted = true;
    }

    private void Update()
    {
        //Testers
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            ResetDifficulty();
            StartTimer();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            UpDifficulty();
        }

        if (hasTimerStarted)
        {
            timeLeft -= Time.deltaTime;
           // Debug.Log("Time left:" + timeLeft.ToString());

            if (timeLeft < 0)
            {
                timeLeft = 0;
                hasTimerStarted = false;
                GLOBAL.instance.M_event.Fire_EVT_Game_Over();
            }
        }
    }

    //Lerps the value based on number of dificulty steps for both display waiting time and sequence lenght
    public void UpDifficulty() {

        //Sequence Value
        if (sequencePercent < 1.0f)
        {
            sequencePercent = sequencePercent + sequencePercentToAdd;
        }
        else {
            sequencePercent = 1.0f;
        }
        currentSequenceValue = Mathf.Lerp(minSequenceValue, maxSequenceValue, sequencePercent);
        Debug.Log("Current Sequence:" + currentSequenceValue);

        //Display Time
        if (displayTimePercent < 1.0f)
        {
            displayTimePercent = displayTimePercent + displayTimePercentToAdd;
        }
        else
        {
            displayTimePercent = 1.0f;
        }
        currentDisplayTime = Mathf.Lerp(maxDisplayTime, minDisplayTime, displayTimePercent);
        Debug.Log("Current Display:" + currentDisplayTime);

    }

}
