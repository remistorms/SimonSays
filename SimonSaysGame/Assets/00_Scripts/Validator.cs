using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script validates that the player input nodes are the same as the randomly generated
public class Validator : MonoBehaviour {

    Node[] localNodes; //Nodes saved locally to compare with player pressed nodes
    int index;

	void Start () {
        GLOBAL.instance.M_event.EVT_Node_Pressed += OnNodePressed;
        GLOBAL.instance.M_event.EVT_Game_Over += OnGameOver;
	}

    public void Activate(Node[] nodes) {
        localNodes = nodes;
        index = 0;
    }

    void OnNodePressed(Node node) {
        string actualID = localNodes[index].nodeID;
        string pressedID = node.nodeID;
        if (actualID == pressedID)
        {
            //Match
            GLOBAL.instance.M_event.Fire_EVT_Display_Blackboard("correct");
            index++;
            if (index >= localNodes.Length)
            {
                StartCoroutine(SequenceCompleteRoutine());
            }
        }
        else {
            //Wrong answer
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

    //Succesfully completed coroutine
    IEnumerator SequenceCompleteRoutine() {
        GLOBAL.instance.M_event.Fire_EVT_Display_Blackboard("Excelent !!!");
        yield return new WaitForSeconds(2);
        GLOBAL.instance.M_event.Fire_EVT_Display_Blackboard("Next round");
        yield return new WaitForSeconds(1);
        GLOBAL.instance.M_event.Fire_EVT_Sequence_Completed();
        localNodes = null;
        index = -1;
    }


}
