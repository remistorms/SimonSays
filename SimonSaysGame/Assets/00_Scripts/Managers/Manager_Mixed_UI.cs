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
     

        //Gets all references, 
        for (int i = 0; i < menuScreens.Length; i++)
        {
            menusRects[i] = menuScreens[i].GetComponent<RectTransform>();
            menusCanvas[i] = menuScreens[i].GetComponent<CanvasGroup>();
        }
        SwitchScreens(0);
    }

    public void DisableScreens() {
        //centers the screens and deactivate them
        for (int i = 0; i < menusRects.Length; i++)
        {
            menusRects[i].GetComponent<UI_Mixed_Screen>().DeactivateScreen();
        }
    }


    public void SwitchScreens(int screenID)
    {
        DisableScreens();
        menuScreens[screenID].ActivateScreen();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SwitchScreens(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchScreens(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchScreens(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchScreens(3);
        }
    }
}



