using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validator : MonoBehaviour {

 
    Node[] localNodes;
    int index;

	// Use this for initialization
	void Start () {
        GLOBAL.instance.M_event.EVT_Node_Pressed += OnNodePressed;
        GLOBAL.instance.M_event.EVT_Game_Over += OnGameOver;
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
            GLOBAL.instance.M_event.Fire_EVT_Display_Blackboard((node.nodeIndex+1).ToString() + "st :" + "correct");
            index++;
            if (index >= localNodes.Length)
            {
                StartCoroutine(SequenceCompleteRoutine());
                /*
                Debug.Log("Succesfully Completed Sequence");
                GLOBAL.instance.M_event.Fire_EVT_Display_Blackboard("Excelent !!!");
                yield return new WaitForSeconds(2);
                GLOBAL.instance.M_event.Fire_EVT_Display_Blackboard("Next round");
                yield return new WaitForSeconds(1);

                //Fire event 
                GLOBAL.instance.M_event.Fire_EVT_Sequence_Completed();
                localNodes = null;
                index = -1;*/
            }
        }
        else {
            Debug.Log("WRONG");
           GLOBAL.instance.M_event.Fire_EVT_Game_Over();
        }


    }

    void OnGameOver() {
        StartCoroutine(GameOverRoutine());
    }

    IEnumerator GameOverRoutine() {
        GLOBAL.instance.M_event.Fire_EVT_Display_Blackboard("GAME OVER");
        yield return new WaitForSeconds(2);

    }

    IEnumerator SequenceCompleteRoutine() {
        Debug.Log("Succesfully Completed Sequence");
        GLOBAL.instance.M_event.Fire_EVT_Display_Blackboard("Excelent !!!");
        yield return new WaitForSeconds(2);
        GLOBAL.instance.M_event.Fire_EVT_Display_Blackboard("Next round");
        yield return new WaitForSeconds(1);
        //Fire event 
        GLOBAL.instance.M_event.Fire_EVT_Sequence_Completed();
        localNodes = null;
        index = -1;
    }


}
