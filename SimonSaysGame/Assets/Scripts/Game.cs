using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public int score;
	// Use this for initialization
	void Start () {
        GLOBAL.instance.M_event.EVT_Game_Setup += OnGameSetup;
        GLOBAL.instance.M_event.EVT_Game_Start += OnGameStart;
    }

    void OnGameStart() {
        Debug.Log("Game Script OnGameStart method has been called");
    }

    void OnGameSetup() {
        score = 0;
    }
}
