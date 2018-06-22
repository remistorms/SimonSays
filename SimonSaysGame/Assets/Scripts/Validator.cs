using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validator : MonoBehaviour {

 
    public Node[] localNodes;
    int index;

    public static Validator instance;

	// Use this for initialization
	void Start () {
        GLOBAL.instance.M_event.EVT_Node_Pressed += OnNodePressed;
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Activate(Node[] nodes) {
        Debug.Log("Validator ACTIVATED");
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
            if (index >= localNodes.Length)
            {
                Debug.Log("Succesfully Completed Sequence");
                //Fire event 
                GLOBAL.instance.M_event.Fire_EVT_Sequence_Completed();
                localNodes = null;
                index = -1;
            }
        }
        else {
            Debug.Log("WRONG");
            GLOBAL.instance.M_event.Fire_EVT_Game_Over();
        }
    }
}
