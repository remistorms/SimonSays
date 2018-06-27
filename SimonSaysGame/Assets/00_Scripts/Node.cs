using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Node : MonoBehaviour {

    //OwlBehaviour owlBehaviour;
    //BoxCollider nodeCollider;
    public string nodeID;
    public int nodeIndex;
    Button button;
    Transform camToFollow;

	// Use this for initialization
	void Start () {

        camToFollow = Camera.main.transform;
        button = GetComponent<Button>();
        nodeIndex = transform.GetSiblingIndex();
        nodeID = gameObject.name.Substring(gameObject.name.Length-2);
        GLOBAL.instance.M_event.EVT_Game_Start += OnGameStart;
        GLOBAL.instance.M_event.EVT_Game_Over += OnGameOver;
        GLOBAL.instance.M_event.EVT_Presentation_Start += OnPresentationStarted;
        GLOBAL.instance.M_event.EVT_Presentation_Finished += OnPresentationFinished;
        GLOBAL.instance.M_event.EVT_Sequence_Completed += OnSequenceCompleted;
    }

    private void LateUpdate()
    {
        transform.LookAt(camToFollow);
    }

    void OnGameStart() {
        button.enabled = true;
    }

    void OnGameOver() {
        button.enabled = false;
    }

    public void NodeClicked() {
        GLOBAL.instance.M_event.Fire_EVT_Node_Pressed(this);
    }

    public void FlashColor() {
        transform.DOPunchScale(Vector3.one, 0.2f);
    }

    void OnPresentationStarted() {
        button.enabled = false;
    }

    void OnPresentationFinished()
    {
        button.enabled = true;
    }

    void OnSequenceCompleted() {
        button.enabled = false;
    }

    public void PressedButton() {
        GLOBAL.instance.M_event.Fire_EVT_Node_Pressed(this);
    }
}
