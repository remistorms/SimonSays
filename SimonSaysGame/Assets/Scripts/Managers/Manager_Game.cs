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
        base.Initialize();
        state = State.None;
    }

  
}
