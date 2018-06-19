using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegatesAndEvents : MonoBehaviour {

    //1.- Define delegates and events

    //2.- Trigger the events

    //3.- Subscribe game objects to the events

    public delegate void UnitEventHandler(GameObject unit);
    public delegate void ButtonPressedEvent(int buttonID);

    public static event UnitEventHandler onUnitSpawn;
    public static event UnitEventHandler onUnitDestroy;

    public static void NewUnitCreated(GameObject unit) {

        if (onUnitSpawn != null)
        {
            onUnitSpawn(unit);
        }
    }

    public static void UnitDead(GameObject unit)
    {

        if (onUnitSpawn != null)
        {
            onUnitSpawn(unit);
        }
    }


}
