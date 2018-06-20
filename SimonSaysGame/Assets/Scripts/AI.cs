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
            Debug.Log(GetNumSequence());
            score++;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string[] GetSequence() {
        return new string[0] ;
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
