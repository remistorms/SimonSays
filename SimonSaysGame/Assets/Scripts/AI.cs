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
        GLOBAL.instance.M_event.EVT_Game_Start += OnGameStart;
        GLOBAL.instance.M_event.EVT_Sequence_Completed += OnSequenceCompleted;

        /*
        for (int i = 0; i < 20; i++)
        {
            Node[] nodeArray = GetSequence();
            for (int j = 0; j < nodeArray.Length; j++)
            {
                Debug.Log(nodeArray[j].nodeID);
            }
            Debug.Log(" ");
            score++;
        }*/
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
           // presentationRef.DisplayNodeSequence(GetSequence());
        }
	}

    public Node[] GetSequence() {

        //Get number sequence
        int numSequence = GetNumSequence();
        Node[] sequence = new Node[numSequence];
        //Get a random number from the nodes array that this method will return
        for (int i = 0; i < numSequence; i++)
        {
            int random = Random.Range(0, nodes.Count);
            
            Node selectedNode = nodes[random];
            
            sequence[i] = selectedNode;
        }

        return sequence;
    }

    //This one will give us the amount of node per difficulty
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
            return 5;
        }
    }

    void OnGameStart() {
        presentationRef.DisplayNodeSequence(GetSequence());
    }

    void OnSequenceCompleted() {
        presentationRef.DisplayNodeSequence(GetSequence());
    }
}
