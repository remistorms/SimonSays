using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesNo : MonoBehaviour {

   public Transform cam;
   public Transform yesButton, noButton;
    public Transform playAgain, quitGame;

    private void Start()
    {
        cam = Camera.main.transform;
        Deactivate();
        GLOBAL.instance.M_event.EVT_Game_Over += OnGameOver;
        GLOBAL.instance.M_event.EVT_Game_Start += OnGameStart;
        GLOBAL.instance.M_event.EVT_Game_Setup += OnGameStart;
  
    }
    public void Understood() {
        Debug.Log("Understood");
        GLOBAL.instance.M_event.EVT_Tutorial_Finished();
        Deactivate();
    }

    public void RepeatTutorial() {
        GLOBAL.instance.M_event.Fire_EVT_Repeat_Tutorial();
        Deactivate();
    }

    public void RetryGame() {
        GLOBAL.instance.M_event.Fire_EVT_Game_Setup();

    }

    public void QuitGame() {
        Application.Quit();
    }

    private void LateUpdate()
    {
        yesButton.LookAt(cam);
        noButton.LookAt(cam);
    }

   public void Deactivate() {
        Debug.Log("Deactivate Buttons");
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        playAgain.gameObject.SetActive(false);
        quitGame.gameObject.SetActive(false);
    }

   public void Activate() {
        Debug.Log("Activate Buttons");
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
    }

    public void ShowRetryButtons()
    {
        Debug.Log("Deactivate Buttons");
        playAgain.gameObject.SetActive(false);
        quitGame.gameObject.SetActive(false);
    }

    public void HideRetryButtons()
    {
        Debug.Log("Activate Buttons");
        playAgain.gameObject.SetActive(true);
        quitGame.gameObject.SetActive(true);
    }

    void OnGameOver() {
        StartCoroutine(GameOverRoutine());
    }

    IEnumerator GameOverRoutine() {
        yield return new WaitForSeconds(2);
        GLOBAL.instance.M_event.Fire_EVT_Display_Blackboard("Retry?");
        Deactivate();
        ShowRetryButtons();

    }

    void OnGameStart() {
        Deactivate();
        HideRetryButtons();
    }

    void Retry() {
        GLOBAL.instance.M_event.Fire_EVT_Game_Start();
    }
}
