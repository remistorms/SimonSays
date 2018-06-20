using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour {

    public void ShowGameUI() {
        GLOBAL.instance.M_ui.ShowScreen(UIScreen.Enum_Screen.InGame);
        Debug.Log("Show Game UI");
    }
}
