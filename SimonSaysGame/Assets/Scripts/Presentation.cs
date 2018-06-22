﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presentation : MonoBehaviour {

    Validator validatorRef;
	// Use this for initialization
	void Start () {
        validatorRef = GetComponent<Validator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayNodeSequence(Node[] nodes) {
        Debug.Log("Displaye Node Sequence Method");
        //StartCoroutine(DisplayNodesRoutine(nodes));
        GLOBAL.instance.ui3D.teacherCanvas.ShowTeacherLongDialogue(nodes);
    }

    IEnumerator DisplayNodesRoutine(Node[] nodes) {
        //Fire presentation Start EVENT for buttons to listen
        GLOBAL.instance.M_event.Fire_EVT_Presentation_Start();
        yield return null;

        GLOBAL.instance.ui3D.teacherCanvas.ShowTeacherLongDialogue(nodes);
        yield return new WaitForSeconds(7);

        validatorRef.Activate(nodes);
        //Fire END presentation EVENT
        GLOBAL.instance.M_event.Fire_EVT_Presentation_Finished();
    }

   
}
