﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Presentation : MonoBehaviour {

    Validator validatorRef;
    public YesNo tutorialAnswers;
    public TextMeshProUGUI blackboardText;

	// Use this for initialization
	void Start () {
        validatorRef = GetComponent<Validator>();
        GLOBAL.instance.M_event.EVT_Game_Start += OnGameStart;
        GLOBAL.instance.M_event.EVT_Repeat_Tutorial += OnTutorialRepeat;
        GLOBAL.instance.M_event.EVT_Replay_Game += OnReplayGame;
        //tutorialAnswers.Deactivate();

	}

    void OnReplayGame() {
        StartCoroutine(ReplayRoutine());
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayNodeSequence(Node[] nodes) {
            StartCoroutine(DisplayNodesRoutine(nodes));
    }

    IEnumerator DisplayNodesRoutine(Node[] nodes) {
        //Fire presentation Start EVENT for buttons to listen
        GLOBAL.instance.M_event.Fire_EVT_Presentation_Start();
        yield return null;

        GLOBAL.instance.M_event.Fire_EVT_Display_Blackboard("Ready...");
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < nodes.Length; i++)
        {
            //Display here on the blackboard 
            string textToDisplay = (nodes[i].nodeIndex + 1).ToString() ; 
            GLOBAL.instance.M_event.Fire_EVT_Display_Blackboard(textToDisplay);
            yield return new WaitForSeconds(1.0f);
            GLOBAL.instance.M_event.Fire_EVT_Display_Blackboard("...");
            yield return new WaitForSeconds(0.25f);
        }

        GLOBAL.instance.M_event.Fire_EVT_Display_Blackboard("Your turn");
        yield return new WaitForSeconds(1);

        GLOBAL.instance.M_event.Fire_EVT_WaitingForPlayerInput();
        yield return new WaitForSeconds(1);

        validatorRef.Activate(nodes);
        //Fire END presentation EVENT
        GLOBAL.instance.M_event.Fire_EVT_Presentation_Finished();
    }

    IEnumerator TutorialRoutine() {
        GLOBAL.instance.M_event.Fire_EVT_Tutorial_Started();
        yield return new WaitForSeconds(2);
        blackboardText.text = "Kids !!!";
        yield return new WaitForSeconds(3);
        blackboardText.text = "Its memory training day";
        yield return new WaitForSeconds(3);
        blackboardText.text = "Memorize the numbers on the blackboard";
        yield return new WaitForSeconds(2);
        blackboardText.text = "At the end of each round its your turn to answer";
        yield return new WaitForSeconds(2);
        blackboardText.text = "One wrong answer is game over";
        yield return new WaitForSeconds(2);
        blackboardText.text = "Understood?";
        UI_3D.instance.ShowUnderstood();
    }

    IEnumerator ReplayRoutine() {
        yield return null;
        blackboardText.text = "Perfect here we go again";
        yield return new WaitForSeconds(2);
        GLOBAL.instance.M_event.EVT_Tutorial_Finished();
    }

    IEnumerator EndSequenceRoutine() {
        blackboardText.text = "Amazing !!!";
        yield return new WaitForSeconds(1);
        blackboardText.text = "Let's continue with the next round";
        yield return new WaitForSeconds(2);
    }

    void OnGameStart() {
        StartCoroutine(TutorialRoutine());
    }

    void OnTutorialRepeat() {
        StartCoroutine(TutorialRoutine());
    }
}
