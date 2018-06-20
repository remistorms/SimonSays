using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_UI : Manager {
    
    //key value pairs
    private Dictionary<UIScreen.Enum_Screen, UIScreen> screensDictionary;

    //Need something to get a reference to currentScreen
    private UIScreen.Enum_Screen currentScreen;

    public override void Initialize()
    {
        Debug.Log("Manager UI Initialize has been called");
        screensDictionary = new Dictionary<UIScreen.Enum_Screen, UIScreen>();
        currentScreen = UIScreen.Enum_Screen.None;
    }

    //This method is used to add whichever screens into this dictionary 
    public void RegisterScreen(UIScreen screen) {
        screensDictionary.Add(screen.screenType, screen);
    }

    //GLOBAL method to show screens
    public void ShowScreen(UIScreen.Enum_Screen screenEnum) {
        Debug.Log("screenEnum = " + screenEnum);
        //If there is another screen currently shown, hide it before showing the new one
        if (currentScreen != UIScreen.Enum_Screen.None)
        {
            screensDictionary[currentScreen].Hide();
        }
        screensDictionary[screenEnum].Show();
        //Current screen = screenEnum;
        currentScreen = screenEnum;
    }
}
