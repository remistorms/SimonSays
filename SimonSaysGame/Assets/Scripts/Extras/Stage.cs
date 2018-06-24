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
    public AudioSource audioSource;
    public SkinnedMeshRenderer curtainsMesh;
    public MeshRenderer outsideWallsMesh;
    public CanvasGroup titleCanvasGroup;

    private void Start()
    {
        ResetStage();
        GLOBAL.instance.M_event.EVT_Game_Setup += OnGameSetup;
        GLOBAL.instance.M_event.EVT_Game_Over += OnGameOver;
        GLOBAL.instance.M_event.EVT_Game_Start += OnGameStart;
        GLOBAL.instance.M_event.EVT_Score_Changed += OnScoreChanged;
        audioSource = GetComponent<AudioSource>();
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

        outsideTrunk.gameObject.SetActive(true);
        outsideTrunk.material.color = new Color(outsideTrunk.material.color.r,
            outsideTrunk.material.color.g,
            outsideTrunk.material.color.b,
            0f);
        outsideTrunk.material.DOFade(1, time);
        yield return new WaitForSeconds(time);
        //insideTrunk.gameObject.SetActive(false);
             
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
        titleCanvasGroup.gameObject.SetActive(true);
        titleCanvasGroup.alpha = 1;
    }

    void OnGameSetup() {
        ResetStage();
        audioSource.Stop();
    }

    void OnGameOver() {

    }

    void OnGameStart() {
        OpenCurtains(1);
        FadeOutWalls(1);
        FadeTitle(1);
        audioSource.clip = GLOBAL.instance.M_sound.backgroundMusic[Random.Range(0, GLOBAL.instance.M_sound.backgroundMusic.Length)];
        audioSource.Play();
    }

    void OnScoreChanged(int score) {

    }

    void FadeTitle(float time) {
        StartCoroutine(FadeTitleRoutine(time));
    }

    IEnumerator FadeTitleRoutine(float time) {
        titleCanvasGroup.DOFade(0, time);
        yield return new WaitForSeconds(time);
        titleCanvasGroup.gameObject.SetActive(false);
    }
}
