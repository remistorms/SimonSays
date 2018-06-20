using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScreen : MonoBehaviour {


    public enum Enum_Screen {
        None,//0
        MainMenu,//1
        InGame,//2
        PostGame//3
    }

    public Enum_Screen screenType;

    private CanvasGroup canvasGroupRef;

	// Use this for initialization
	void Start () {
        canvasGroupRef = GetComponent<CanvasGroup>();
        Hide();
        //Register this screen to the UI Manager
        GLOBAL.instance.M_ui.RegisterScreen(this);
	}

    public void Show() {
        canvasGroupRef.alpha = 1;
        canvasGroupRef.interactable = true;
        canvasGroupRef.blocksRaycasts = true;
    }

    public void Hide()
    {
        canvasGroupRef.alpha = 0;
        canvasGroupRef.interactable = false;
        canvasGroupRef.blocksRaycasts = false;
    }
}
