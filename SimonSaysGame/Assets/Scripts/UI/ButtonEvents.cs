using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour {

    public void ShowGameUI() {
        GLOBAL.instance.M_ui.ShowScreen(UIScreen.Enum_Screen.InGame);
        //Fire event game setup
        GLOBAL.instance.M_event.Fire_EVT_Game_Setup();
        Debug.Log("Show Game UI");
    }


}
