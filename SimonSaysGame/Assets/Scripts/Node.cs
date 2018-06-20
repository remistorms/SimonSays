using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    BoxCollider nodeCollider;
    public string nodeID;

	// Use this for initialization
	void Start () {
      
        nodeID = gameObject.name.Substring(gameObject.name.Length-2);
        nodeCollider = GetComponent<BoxCollider>();
        nodeCollider.enabled = false;
        GLOBAL.instance.M_event.EVT_Game_Start += OnGameStart;
        GLOBAL.instance.M_event.EVT_Game_Over += OnGameOver;
    }

    void OnGameStart() {
        nodeCollider.enabled = true;
    }

    void OnGameOver() {
        nodeCollider.enabled = false;
    }

    public void OnButtonDown() {
        Debug.Log("Button Down");
    }
}
