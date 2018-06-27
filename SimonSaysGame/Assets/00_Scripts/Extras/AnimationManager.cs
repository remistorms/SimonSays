using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationManager : MonoBehaviour {

    public static AnimationManager instance;
    public Animator teacherAnimator;
    public Animator[] kidsAnimators;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GLOBAL.instance.M_event.EVT_Game_Setup += OnGameSetup;
        GLOBAL.instance.M_event.EVT_Game_Start += OnGameStart;
        GLOBAL.instance.M_event.EVT_WaitingForPlayerInput += OnWaitingForPlayerInput;
        GLOBAL.instance.M_event.EVT_Sequence_Completed += OnSequenceCompleted;
        GLOBAL.instance.M_event.EVT_PayAttention += OnTeacherCall;
        GLOBAL.instance.M_event.EVT_Game_Over += AllCry;
        GLOBAL.instance.M_event.EVT_Replay_Game += OnTeacherCall;
    }

    void OnGameSetup() {

        StartCoroutine(CelebrateRoutine(5));
    }

    void OnGameStart() {

        StartCoroutine(CelebrateRoutine(5));

    }

    void AllCry() {
        foreach (var item in kidsAnimators)
        {
            item.gameObject.transform.DOLocalRotate(new Vector3(0, Random.Range(90, 270), 0), 0.5f);
            item.SetTrigger("cry");
        }
    }
  
    public void JumpOwl(int id) {
        kidsAnimators[id].SetTrigger("jump");
    }

    //Called then event Waiting for player input is fired
    void OnWaitingForPlayerInput() {
        foreach (var item in kidsAnimators)
        {
            item.gameObject.transform.DOLocalRotate(new Vector3(0, 180, 0), 0.5f);
            item.SetTrigger("idle");
        }

        teacherAnimator.SetTrigger("teaching");
    }

    //Called when event sequence completed is fired
    void OnSequenceCompleted() {
        foreach (var item in kidsAnimators)
        {
            item.gameObject.transform.DOLocalRotate(new Vector3(0, 180, 0), 0.2f);
            item.SetTrigger("idle");
        }

        teacherAnimator.SetTrigger("preparing");
    }

    //Animates the kids back to original state before next round
    void OnTeacherCall() {
        foreach (var item in kidsAnimators)
        {
            item.gameObject.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
            item.SetTrigger("idle");
        }
    }

    //Animates the kids x number of times 
    public IEnumerator CelebrateRoutine(int times) {
        for (int i = 0; i < times; i++)
        {
            Celebrate();
            yield return new WaitForSeconds(0.5f);
        }

        foreach (var item in kidsAnimators)
        {
            item.gameObject.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
            item.SetTrigger("fly");
        }
    }

    public void Celebrate() {
        foreach (var item in kidsAnimators)
        {
            item.gameObject.transform.DOLocalRotate(new Vector3(0, Random.Range(0, 360), 0), 0.2f);
            item.SetTrigger("jump");
        }
    }
}
