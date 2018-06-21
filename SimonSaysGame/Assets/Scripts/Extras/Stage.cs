using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class Stage : MonoBehaviour {

    public enum State {
        None,
        Closed,
        Open
    };

    public State stageState;
    public SkinnedMeshRenderer curtainsMesh;
    public MeshRenderer outsideWallsMesh;

    private void Start()
    {
        ResetStage();
        GLOBAL.instance.M_event.EVT_Game_Setup += OnGameSetup;
        GLOBAL.instance.M_event.EVT_Game_Over += OnGameOver;
        GLOBAL.instance.M_event.EVT_Game_Start += OnGameStart;
        GLOBAL.instance.M_event.EVT_Score_Changed += OnScoreChanged;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            OpenCurtains(1.5f);
            FadeOutWalls(1.5f);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CloseCurtains(1.5f);
            FadeInWalls(1.5f);
        }
    }

    public void FadeOutWalls(float time) {
        StartCoroutine(FadeOutWallsRoutine(time));
    }

    IEnumerator FadeOutWallsRoutine(float time) {
        outsideWallsMesh.material.DOFade(0, time);
        
        yield return new WaitForSeconds(time);
        outsideWallsMesh.gameObject.SetActive(true);
       
    }

    public void FadeInWalls(float time)
    {
        outsideWallsMesh.gameObject.SetActive(true);
        
        outsideWallsMesh.material.DOFade(1, time);
        
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

    public void ResetStage() {
        stageState = State.Closed;
        outsideWallsMesh.gameObject.SetActive(true);
        outsideWallsMesh.material.color = new Color(outsideWallsMesh.material.color.r,
            outsideWallsMesh.material.color.g,
            outsideWallsMesh.material.color.b,
            1f);
        curtainsMesh.SetBlendShapeWeight(0, 0);
    }

    void OnGameSetup() {
        ResetStage();
    }

    void OnGameOver() {

    }

    void OnGameStart() {

    }

    void OnScoreChanged(int score) {

    }
}
