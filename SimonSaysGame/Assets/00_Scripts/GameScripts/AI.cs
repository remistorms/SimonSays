using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    //Manager_Difficulty difficultyRef;
    private Game gameRef;
    public List<Node> nodes;
    Presentation presentationRef;
    float tempFloat;
    int tempInt;

	// Use this for initialization
	void Start () {
        gameRef = GetComponent<Game>();
        presentationRef = GetComponent<Presentation>();
        GLOBAL.instance.M_event.EVT_Sequence_Completed += OnSequenceCompleted;
        GLOBAL.instance.M_event.EVT_Tutorial_Finished += OnTutorialFinished;

	}

    //Gets the sequence to display and then returns the nodes array
    public Node[] GetSequence() {
        int numSequence = GetNumSequence();
        Node[] sequence = new Node[numSequence];
        for (int i = 0; i < numSequence; i++){
            int random = Random.Range(0, nodes.Count);
            Node selectedNode = nodes[random]; 
            sequence[i] = selectedNode;
        }
        return sequence;
    }

    //Simple Difficulty Ramping based on current score
    //We could even add less time to display on blackboard or even more # combinations
    public int GetNumSequence() {

        // OLD DIFFICULTY SYSTEM
        /*
        if (gameRef.score < 3)
        {
            return 3;
        }
        else if (gameRef.score < 6)
        {
            return 4;
        }
        else
        {
            return 6;
        }*/

        tempFloat = GLOBAL.instance.M_Difficulty.currentSequenceValue;
        tempInt = Mathf.RoundToInt(tempFloat);
        return tempInt;
    }

    void OnTutorialFinished() {
        StartCoroutine(StartWithDelay(2));
    }

    void OnSequenceCompleted() {
        StartCoroutine(StartWithDelay(3));
    }

    IEnumerator StartWithDelay(float delay) {
        yield return new WaitForSeconds(delay);
        presentationRef.DisplayNodeSequence(GetSequence());
    }
}
