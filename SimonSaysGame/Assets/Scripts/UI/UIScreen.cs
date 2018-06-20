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
    private RectTransform rectTransformRef;

	// Use this for initialization
	void Start () {
        canvasGroupRef = GetComponent<CanvasGroup>();
        //Get reference to the rect transform
        rectTransformRef = GetComponent<RectTransform>();
        Hide();
        //Register this screen to the UI Manager
        GLOBAL.instance.M_ui.RegisterScreen(this);
        
	}

    public void Show() {
        rectTransformRef.anchoredPosition = Vector2.zero;
        canvasGroupRef.alpha = 1;
        //
        if (screenType != Enum_Screen.InGame)
        {
            canvasGroupRef.interactable = true;
            canvasGroupRef.blocksRaycasts = true;
        }
        
    }

    public void Hide()
    {
        rectTransformRef.anchoredPosition = new Vector2(2400, 0);
        canvasGroupRef.alpha = 0;
        canvasGroupRef.interactable = false;
        canvasGroupRef.blocksRaycasts = false;
    }
}
