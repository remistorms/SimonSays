﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_3D : MonoBehaviour {

    public TeacherCanvas teacherCanvas;
    public StudentCanvas studentsCanvas;
   // public ScoreCanvas scoreCanvas;

    private void Start()
    {
        GLOBAL.instance.M_event.EVT_Game_Start += OnGameStart;
        GLOBAL.instance.M_event.EVT_Game_Setup += OnGameSetup;
        GLOBAL.instance.M_event.EVT_Game_Over += OnGameOver;
        GLOBAL.instance.M_event.EVT_Presentation_Start += OnPresentationStart;
        GLOBAL.instance.M_event.EVT_Presentation_Finished += OnPresentationFinished;
        GLOBAL.instance.M_event.EVT_Score_Changed += OnScoreChanged;
        GLOBAL.instance.M_event.EVT_Sequence_Completed += OnSequenceCompleted;
        GLOBAL.instance.ui3D = this;
    }

    public void StartGame() {
       // GLOBAL.instance.M_event.Fire_EVT_Game_Setup();
    }

    void OnGameStart() {
       
    }

    void OnGameSetup()
    {
        
    }

    void OnGameOver()
    {
    }

    void OnPresentationStart()
    {
    }

    void OnPresentationFinished()
    {
    }

    void OnScoreChanged(int score)
    {
    }

    void OnSequenceCompleted()
    {
    }
}
