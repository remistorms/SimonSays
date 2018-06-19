using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Manager_Events : MonoBehaviour {

    public static Manager_Events EM;

    public Action EVT_Game_Start;
    public Action EVT_Game_Over;
    public Action EVT_Button_Pressed;

    private void Awake()
    {
        EM = this;
    }

    //Fire Game Start Event after checking if there are subscribers to it
    public void Fire_EVT_Game_Start(){
        if (EVT_Game_Start != null)
        {
            EVT_Game_Start();
        }
    }

    //I need an event that receives/sends an integer
    public void Fire_EVT_Button_Pressed(){
        if (EVT_Button_Pressed != null)
        {
            EVT_Button_Pressed();
        }
    }

}
