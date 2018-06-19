using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequence : MonoBehaviour {

    public static GameSequence instance;
    public List<int> randomSequence = new List<int>();
    public List<int> playerInput = new List<int>();

	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GenerateRandomSequence(3, 8);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CompareLists();
        }

    }

    //This will generate a random sequence that the player has to follow
    public void GenerateRandomSequence(int steps, int totalButtons){

        //Creates a random sequence of N steps based on the total buttons on board
        for (int i = 0; i < steps; i++)
        {
            int randomNum = Random.Range(0, totalButtons);
            randomSequence.Insert(i, randomNum);
        }
    }

    //This inserts a player input into the proper list for later use
    public void InsertPlayerInputToList(int index, int input) {
        playerInput.Insert(index, input);
    }

    //Compares both RandomSequence and PlayerInput Lists to check if player has it right
    public void CompareLists() {
        //Both sequences are the same, player is right
        if (randomSequence == playerInput)
        {
            Debug.Log("Player has it right");
        }
        else //Player didn't get it right
        {
            Debug.Log("Wrong answer");
        }
    }
}
