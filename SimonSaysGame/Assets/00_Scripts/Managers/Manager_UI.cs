using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_UI : Manager {
    
    //key value pairs
    private Dictionary<UI_Screen.Enum_Screen, UI_Screen> screensDictionary;

    //Need something to get a reference to currentScreen
    private UI_Screen.Enum_Screen currentScreen;

    public override void Initialize()
    {
        Debug.Log("Manager UI Initialize has been called");
        screensDictionary = new Dictionary<UI_Screen.Enum_Screen, UI_Screen>();
        currentScreen = UI_Screen.Enum_Screen.None;
    }

    public void Register_Screen(UI_Screen screen)
    {
        screensDictionary.Add(screen.GetScreenType(), screen);
    }

    //GLOBAL method to show screens
    public void ShowScreen(UI_Screen.Enum_Screen screenEnum) {
        Debug.Log("screenEnum = " + screenEnum);
        //If there is another screen currently shown, hide it before showing the new one
        if (currentScreen != UI_Screen.Enum_Screen.None)
        {
            screensDictionary[currentScreen].Hide();
        }
        screensDictionary[screenEnum].Show();
       
        //Current screen = screenEnum;
        currentScreen = screenEnum;
    }
}
