using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    private int score;
    public List<Node> nodes;
	// Use this for initialization
	void Start () {
        score = 0;
        for (int i = 0; i < 20; i++)
        {
            Node[] nodeArray = GetSequence();
            for (int j = 0; j < nodeArray.Length; j++)
            {
                Debug.Log(nodeArray[j].nodeID);
            }
            Debug.Log(" ");
            score++;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
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
        if (score < 3)
        {
            return 3;
        }
        else if (score < 6)
        {
            return 4;
        }
        else
        {
            return 5;
        }
    }
}
