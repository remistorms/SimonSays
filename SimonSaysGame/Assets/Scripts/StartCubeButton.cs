using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCubeButton : MonoBehaviour {

    BoxCollider boxCollider;

    private void Start()
    {
        GLOBAL.instance.M_event.EVT_Game_Setup += OnGameSetup;
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = true;

    }
    public void StartGameWithCubeCollider() {
        GLOBAL.instance.M_event.Fire_EVT_Game_Setup();
        boxCollider.enabled = false;
    }

    void OnGameSetup() {
        boxCollider.enabled = true;
    }

}
