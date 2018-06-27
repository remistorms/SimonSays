using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public int score;
	// Use this for initialization
	void Start () {
        GLOBAL.instance.M_event.EVT_Game_Setup += OnGameSetup;
        GLOBAL.instance.M_event.EVT_Sequence_Completed += OnSequenceCompleted;
    }

    void OnGameSetup() {
        score = 0;
        GLOBAL.instance.M_event.Fire_EVT_Score_Changed(score);
    }

    void OnSequenceCompleted() {
        score++;
        GLOBAL.instance.M_event.Fire_EVT_Score_Changed(score);
    }
}
