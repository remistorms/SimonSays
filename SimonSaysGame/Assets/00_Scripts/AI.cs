using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    private Game gameRef;
    public List<Node> nodes;
    Presentation presentationRef;

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

    //This one will give us the amount of nodes per difficulty
    public int GetNumSequence() {
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
        }
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
