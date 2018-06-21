﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Node : MonoBehaviour {

    BoxCollider nodeCollider;
    public string nodeID;

	// Use this for initialization
	void Awake () {
      
        nodeID = gameObject.name.Substring(gameObject.name.Length-2);
        nodeCollider = GetComponent<BoxCollider>();
        nodeCollider.enabled = false;
        GLOBAL.instance.M_event.EVT_Game_Start += OnGameStart;
        GLOBAL.instance.M_event.EVT_Game_Over += OnGameOver;
        GLOBAL.instance.M_event.EVT_Presentation_Start += OnPresentationStarted;
        GLOBAL.instance.M_event.EVT_Presentation_Finished += OnPresentationFinished;
    }

    void OnGameStart() {
        nodeCollider.enabled = true;
    }

    void OnGameOver() {
        nodeCollider.enabled = false;
    }

    public void OnButtonDown() {
        Debug.Log("Button Down");
        FlashColor();
    }

    public void FlashColor() {
        transform.DOPunchScale(Vector3.one, 0.2f);
    }

    void OnPresentationStarted() {
        nodeCollider.enabled = false;
    }

    void OnPresentationFinished()
    {
        nodeCollider.enabled = true;
    }
}
