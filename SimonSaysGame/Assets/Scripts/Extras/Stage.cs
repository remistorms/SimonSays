using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stage : MonoBehaviour {

    public SkinnedMeshRenderer curtainsMesh;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            OpenCurtains(1.5f);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CloseCurtains(1.5f);
        }
    }

    public void OpenCurtains(float time) {
        Debug.Log("Opening Curtains");
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", 0,
            "to", 100,
            "time", time, 
            "onupdate", "UpdateFloat",
            "onupdatetarget", gameObject,
            "easetype", iTween.EaseType.linear
            ));
    }

    public void CloseCurtains(float time)
    {
        Debug.Log("Closing Curtains");
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", 100,
            "to", 0,
            "time", time,
            "onupdate", "UpdateFloat",
            "onupdatetarget", gameObject,
            "easetype", iTween.EaseType.linear
            ));
    }

    public void UpdateFloat(float value) {

        curtainsMesh.SetBlendShapeWeight(0, value);
    }
}
