using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour {

    public GameObject buttonPrefab;
    public List<GameObject> allButtons;
    public List<Vector3> buttonPositions;
    public float distanceBetweenButtons;
    public int columns, rows;

    Vector3 buttonPosition;

    void Start() {
        GenerateButtons(16);
        PlaceButtons();
      
    }

    //Generates buttons and places them on the List
    public void GenerateButtons(int totalButtons) {

        for (int i = 0; i < totalButtons; i++)
        {
            //creates a button
            GameObject button = Instantiate(buttonPrefab, this.transform) as GameObject;
            //sets the corresponding button ID for later use
            button.GetComponent<ButtonScript>().buttonID = i;
            //Places created button into List
            allButtons.Insert(i, button); 
        }

    }

    public void PlaceButtons() {
        for (int y = 0; y < columns; y++)
        {
            for (int x = 0; x < rows; x++)
            {
                Vector3 myVector = new Vector3(x, 0, -y);
                buttonPositions.Add( myVector * distanceBetweenButtons);
            }      
        }

        for (int i = 0; i < allButtons.Capacity; i++)
        {
            allButtons[i].transform.position = buttonPositions[i];
        }
    }

    void RecenterGrid() {
        //Do something to recenter
    }
}
