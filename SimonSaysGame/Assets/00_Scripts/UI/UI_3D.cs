using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class UI_3D : MonoBehaviour {

    public static UI_3D instance;

    [Header("Main UI Containers")]
    public RectTransform frontCanvas;
    public RectTransform kidsCanvas;
    public RectTransform blackboardCanvas;
    Vector3 frontCanvasOriginalScale;

    [Header("Blackboard elements")]
    public TextMeshProUGUI blackboardSequenceText;
    public TextMeshProUGUI blackboardScoreText;

    [Header("Popup Messages")]
    public GameObject understoodParent, replayParent;
    public GameObject[] followPlayerButtons;
    Transform camTransform;
    public bool hasPlacedScene;

    private void Awake()
    {
        instance = this;
        hasPlacedScene = false;
    }

    private void Start()
    {
   
        GLOBAL.instance.M_event.EVT_Game_Start += OnGameStart;
        GLOBAL.instance.M_event.EVT_Game_Setup += OnGameSetup;
        GLOBAL.instance.M_event.EVT_Game_Over += OnGameOver;
        GLOBAL.instance.M_event.EVT_Score_Changed += OnScoreChanged;
        GLOBAL.instance.M_event.EVT_Display_Blackboard += OnDisplayBlackboard;
        GLOBAL.instance.M_event.EVT_Stage_Positioned += ActivateButtonsFollowCam;
        frontCanvasOriginalScale = frontCanvas.localScale;
        HidePopups();
        camTransform = Camera.main.transform;
     
    }

    void ActivateButtonsFollowCam() {
        hasPlacedScene = true;
    }

    private void LateUpdate()
    {
        //Keeps the UI Buttons looking at main Camera
        if (hasPlacedScene)
        {
            foreach (var item in followPlayerButtons)
            {
                item.transform.LookAt(camTransform);
            }
        }
        
    }

    public void RetryGame() {
        GLOBAL.instance.M_event.Fire_EVT_Replay_Game();
        HidePopups();
    }

    public void StartGame() {
        //GLOBAL.instance.M_event.Fire_EVT_Game_Setup();
        //worldCanvasGroups[0].DOFade(0, 0.5f);
        //GLOBAL.instance.M_event.Fire_EVT_Game_Start();
        GLOBAL.instance.M_event.Fire_EVT_Tutorial_Finished();
        HidePopups();
    }

    void OnDisplayBlackboard(string text) {
        blackboardSequenceText.text = text;
    }

    void OnGameStart() {
        frontCanvas.localScale = Vector3.zero;
        HidePopups();
    }

    void OnGameSetup()
    {
        frontCanvas.localScale = frontCanvasOriginalScale;
        HidePopups();
    }

    void OnGameOver()
    {
        ShowReplay();
    }

    void OnScoreChanged(int score)
    {
        blackboardScoreText.text = "Score: " + score;
    }

    public void PlayButtonPressed() {
        StartCoroutine(StartRoutine());
    }

    IEnumerator StartRoutine() {

        GLOBAL.instance.M_event.Fire_EVT_Game_Start();
        AnimationManager.instance.CelebrateRoutine(8);
        yield return new WaitForSeconds(5); 
    }

    public void ShowUnderstood() {
        understoodParent.SetActive(true);
        replayParent.SetActive(false);
    }

    public void ShowReplay() {
        understoodParent.SetActive(false);
        replayParent.SetActive(true);
    }

    public void HidePopups() {
        understoodParent.SetActive(false);
        replayParent.SetActive(false);
    }

    void OnTutorialFinished()
    {
        HidePopups();
    }

    public void RepeatTutorial() {
        GLOBAL.instance.M_event.Fire_EVT_Repeat_Tutorial();
        HidePopups();
        GLOBAL.instance.M_event.Fire_EVT_Display_Blackboard("Once again...");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
