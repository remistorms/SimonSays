using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using UnityEngine.UI;

public class TurnOnObjects : MonoBehaviour {

    public GameObject stage;
    public GameObject[] insideObjects;
    public GameObject[] outsideObjects;
    public float localScale;
    public Slider floatSlider;

	// Use this for initialization
	void Start () {

        GLOBAL.instance.M_event.EVT_AR_HitOnPlane += OnArHitPlane;
        foreach (var item in insideObjects) item.SetActive(false);
        //stage.SetActive(false);
        foreach (var item in insideObjects)
        {
            item.SetActive(false);
        }
	}

    public void OnArHitPlane(TrackableHit hit) {

        //stage.SetActive(true);
        
        //stage.transform.Rotate(0, k_ModelRotation, 0, Space.Self);

        // Create an anchor to allow ARCore to track the hitpoint as understanding of the physical
        // world evolves.
        var anchor = hit.Trackable.CreateAnchor(hit.Pose);

        // Make Andy model a child of the anchor.
        stage.transform.parent = anchor.transform;
        stage.transform.localScale = new Vector3(
            floatSlider.value, 
            floatSlider.value, 
            floatSlider.value
            );
    }


	
}
