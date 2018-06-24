using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UI_Screen : MonoBehaviour {

    public enum Enum_Screen
    {
        None,//0
        MainMenu,//1
        InGame,//2
        PostGame//3
    }

    private CanvasGroup canvasGroupRef;
    private RectTransform rectTransformRef;

    // Use this for initialization
    void Start()
    {
        canvasGroupRef = GetComponent<CanvasGroup>();
        //Get reference to the rect transform
        rectTransformRef = GetComponent<RectTransform>();
        Hide();
        //Register this screen to the UI Manager
        //GLOBAL.instance.M_ui.RegisterScreen(this);
       // GLOBAL.instance.M_ui.Register_Screen(this);
        OnStart();
    }

    protected virtual void OnStart() { }

    public void Show()
    {
        rectTransformRef.anchoredPosition = Vector2.zero;
        canvasGroupRef.alpha = 1;
        //
        if (GetScreenType() != Enum_Screen.InGame)
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

    public abstract Enum_Screen GetScreenType();
}
