using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//Screen ENUMS for easier access down the road
public enum ScreenType
{
    None,
    InGameScreen,
    OptionsScreen,
    DialogueScreen,
    DebugScreen
}

public class Manager_Mixed_UI : MonoBehaviour {

    // Dictionary<int, StudentName> students = new Dictionary<int, StudentName>()
    public Dictionary<ScreenType, UI_Mixed_Screen> screensDictionary; 
    public UI_Mixed_Screen[] menuScreens;
    public RectTransform[] menusRects;
    public CanvasGroup[] menusCanvas;

    private void Awake()
    {
        
        InitialSetup();
    }

    private void Start()
    {
       // DebugDictionary();
    }

    public void InitialSetup()
    {
        //Init
        menusRects = new RectTransform[menuScreens.Length];
        menusCanvas = new CanvasGroup[menuScreens.Length];
        screensDictionary = new Dictionary<ScreenType, UI_Mixed_Screen>();

        //Gets all references, 
        for (int i = 0; i < menuScreens.Length; i++)
        {
            menusRects[i] = menuScreens[i].GetComponent<RectTransform>();
            menusCanvas[i] = menuScreens[i].GetComponent<CanvasGroup>();
        }

        //DisableScreens
        DisableScreens();
    }

    public void DisableScreens() {
        //centers the screens and deactivate them
        for (int i = 0; i < menusRects.Length; i++)
        {
            menusRects[i].anchoredPosition = Vector2.zero;
            menusCanvas[i].alpha = 0;
            menusCanvas[i].interactable = false;
            menusCanvas[i].blocksRaycasts = false;
            screensDictionary.Add(menuScreens[i].screen, menuScreens[i].GetComponent<UI_Mixed_Screen>());
            menuScreens[i].screenActive = false;
        }
    }

    public void DebugDictionary() {
        foreach (var item in screensDictionary)
        {
            Debug.Log("Key: " + item.Key.ToString() + " Value: " + item.Value.ToString());
        }
    }

    public void SwitchScreens(ScreenType newScreen)
    {

    }
}



