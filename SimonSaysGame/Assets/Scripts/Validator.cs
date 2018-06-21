using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validator : MonoBehaviour {

    public enum State {
        None,
        Idle,
        Active
    };

    public State state;
    Node[] localNodes;
    int index;

	// Use this for initialization
	void Start () {
        GLOBAL.instance.M_event.EVT_Node_Pressed += OnNodePressed;
        state = State.Idle;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Activate(Node[] nodes) {
        Debug.Log("Validator ACTIVATED");
        state = State.Active;
        localNodes = nodes;
        index = 0;

    }

    void OnNodePressed(Node node) {
        // Debug.Log("Node ID pressed = " + node.nodeID);
        string actualID = localNodes[index].nodeID;
        string pressedID = node.nodeID;
        if (actualID == pressedID)
        {
            Debug.Log("MATCH");
            index++;
        }
        else {
            Debug.Log("WRONG");
        }
    }
}
