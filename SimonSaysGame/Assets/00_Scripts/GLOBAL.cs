using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This will be used to access pretty much everything that is important for events and more
public class GLOBAL : MonoBehaviour {

    public static GLOBAL instance;
    public Manager_Event M_event;
    public Manager_Game M_game;
    public Game gameVariables;

    // Use this for initialization
    void Awake () {
        instance = this;
	}

}
