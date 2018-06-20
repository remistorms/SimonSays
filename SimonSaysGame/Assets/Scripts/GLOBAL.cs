using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLOBAL : MonoBehaviour {

    public static GLOBAL instance;
    //References for future uses in game
    public Manager_Event M_event;
    public Manager_UI M_ui;
    public Manager_Sound M_sound;
    public Manager_Game M_game;

    // Use this for initialization
    void Awake () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
