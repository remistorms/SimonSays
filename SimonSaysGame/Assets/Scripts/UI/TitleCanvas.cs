using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleCanvas : MonoBehaviour {

    public CanvasGroup canvasGroup;
    public static TitleCanvas instance;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        instance = this;
        GLOBAL.instance.M_event.EVT_Game_Start += OnGameStart;
        GLOBAL.instance.M_event.EVT_Game_Setup += OnGameSetup;
    }

    public void HideTitle(float time) {
        canvasGroup.DOFade(0, time);
    }

    public void ShowTitle(float time)
    {
        canvasGroup.DOFade(1, time);
    }

    void OnGameStart() {
        canvasGroup.alpha = 0;
    }

    void OnGameSetup() {
        canvasGroup.alpha = 1;
    }
}
