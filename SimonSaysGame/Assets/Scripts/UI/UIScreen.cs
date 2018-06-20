using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScreen : MonoBehaviour {


    public enum Screen {
        None,
        MainMenu,
        InGame,
        PostGame
    }

    public Screen screenType;

    private CanvasGroup canvasGroupRef;

	// Use this for initialization
	void Start () {
        canvasGroupRef = GetComponent<CanvasGroup>();
        canvasGroupRef.alpha = 0;
        canvasGroupRef.interactable = false;
        canvasGroupRef.blocksRaycasts = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
