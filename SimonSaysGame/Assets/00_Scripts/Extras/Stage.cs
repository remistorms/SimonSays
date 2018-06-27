using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class Stage : MonoBehaviour {

    //public AudioSource audioSource;
    public MeshRenderer[] outside, inside;
    public Material fadeMaterial, opaqueMaterial;

    AnimationManager animationManager;

    //Characters reference
    [Header("Character Animation References")]
    public Animator teacherAnimator;
    public Animator[] kidsAnimators;

    private void Start()
    {

        ResetStage();
        GLOBAL.instance.M_event.EVT_Game_Setup += OnGameSetup;
        GLOBAL.instance.M_event.EVT_Game_Over += OnGameOver;
        GLOBAL.instance.M_event.EVT_Game_Start += OnGameStart;
        GLOBAL.instance.M_event.EVT_Score_Changed += OnScoreChanged;
      //  audioSource = GetComponent<AudioSource>();
        foreach (var item in outside)
        {
            item.material = opaqueMaterial;
        }
       
    }

    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            HideOutside(2f);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            SendCharacterAnimators();
        }
    }

    public void HideOutside(float time) {
        StartCoroutine(HideOutsideRoutine(time));
    }

    IEnumerator HideOutsideRoutine(float time) {
        foreach (var item in outside)
        {
            item.material = fadeMaterial;
        }

        yield return null;
        foreach (var item in outside)
        {
            item.material.DOFade(0, time);
        }
        
        yield return new WaitForSeconds(time);
        
        foreach (var item in outside)
        {
            item.gameObject.SetActive(false);
        }


    }

    public void ResetStage() {

        foreach (var item in outside)
        {
            item.material = opaqueMaterial;
            item.gameObject.SetActive(true);
            item.material.color = new Color(item.material.color.r,
                item.material.color.g,
                item.material.color.b,
                1f);
        }


        
    }

    void OnGameSetup() {
        ResetStage();

    }

    void OnGameOver() {

    }

    void OnGameStart() {
        HideOutside(1);
    }

    void OnScoreChanged(int score) {

    }

    public void SendCharacterAnimators() {
        animationManager = GameObject.Find("AnimationManager").GetComponent<AnimationManager>();
        animationManager.teacherAnimator = teacherAnimator;
        animationManager.kidsAnimators = kidsAnimators;
        Debug.Log("Succesfully passsed on animators");

    }
}
