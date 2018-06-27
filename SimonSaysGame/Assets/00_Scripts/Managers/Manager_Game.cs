﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//BASIC GAME LOOP 
public class Manager_Game : Manager {

    public enum State {
        None, 
        Setup,
        Start,
        Restarted,
        GameOver,

    };

    public State state;

    private void Update()
    {
        //HACK
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("HACK has been called");
            GLOBAL.instance.M_event.Fire_EVT_Game_Over();
        }
    }

    public override void Initialize()
    {
        state = State.None;
        Debug.Log("Initialized Manager Game");
        GLOBAL.instance.M_event.EVT_Game_Setup += OnGameSetup;
        GLOBAL.instance.M_event.EVT_Game_Over += OnGameOver;
        GLOBAL.instance.M_event.EVT_Replay_Game += OnGameReplay;
    }

    public void OnGameSetup() {
        Debug.Log("OnGameSetup Method has been called, thank you Events");
        state = State.Setup;

        //StartCoroutine(DelayedStartRoutine(0.5f));
    }

    void OnGameReplay() {
        GetComponent<Game>().score = 0;
        GLOBAL.instance.M_event.Fire_EVT_Score_Changed(0);
    }

    public void OnGameOver() {
        state = State.GameOver;
      //  GLOBAL.instance.M_ui.ShowScreen(UI_Screen.Enum_Screen.PostGame);
    }

    IEnumerator DelayedStartRoutine(float delay) {
        yield return new WaitForSeconds(delay);
        GLOBAL.instance.M_event.Fire_EVT_Game_Start();
        state = State.Start;
    }
}
