using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Game : Manager {

    public enum State {
        None, 
        Setup,
        Start,
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
    }

    public void OnGameSetup() {
        Debug.Log("OnGameSetup Method has been called, thank you Events");
        state = State.Setup;
        StartCoroutine(DelayedStartRoutine());
    }

    public void OnGameOver() {
        state = State.GameOver;
    }

    IEnumerator DelayedStartRoutine() {
        yield return new WaitForSeconds(2);
        GLOBAL.instance.M_event.Fire_EVT_Game_Start();
        state = State.Start;
    }
}
