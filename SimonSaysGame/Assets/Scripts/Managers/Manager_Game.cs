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

    public override void Initialize()
    {
        state = State.None;
        Debug.Log("Initialized Manager Game");
        GLOBAL.instance.M_event.EVT_Game_Setup += OnGameSetup;
    }

    public void OnGameSetup() {
        Debug.Log("OnGameSetup Method has been called, thank you Events");
    }
}
