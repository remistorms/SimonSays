using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GLOBAL.instance.M_event.EVT_Node_Pressed += OnNodePressed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Activate(Node[] nodes) {
        Debug.Log("Validator ACTIVATED");
    }

    void OnNodePressed(Node node) {
        Debug.Log("Node ID pressed = " + node.nodeID);
    }
}
