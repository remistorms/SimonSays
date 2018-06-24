using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Screen_PostGame : UI_Screen {

    public override Enum_Screen GetScreenType()
    {
        return Enum_Screen.PostGame;
    }

    public void ShowGameUI()
    {
        //GLOBAL.instance.M_ui.ShowScreen(UI_Screen.Enum_Screen.InGame);
        //Fire event game setup
        GLOBAL.instance.M_event.Fire_EVT_Game_Setup();
        Debug.Log("Show Game UI");
    }
}
