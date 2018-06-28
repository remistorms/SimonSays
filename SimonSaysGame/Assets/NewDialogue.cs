using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class NewDialogue : MonoBehaviour {

   
    public TextMeshProUGUI dialogueText;
    public CanvasGroup understoodParent, playAgainParent;

    private void Awake()
    {
        Initialize();
    }
    private void Start()
    {
        GLOBAL.instance.M_event.EVT_Display_Blackboard += OnDisplayDialogue;
        GLOBAL.instance.M_event.EVT_Show_Dialogue += ShowDialogue;
        GLOBAL.instance.M_event.EVT_Hide_Dialogue += HideDialogue;
        GLOBAL.instance.M_event.EVT_Show_Play_Again += ShowPlayAgain;
        GLOBAL.instance.M_event.EVT_Hide_Play_Again += HidePlayAgain;
        GLOBAL.instance.M_event.EVT_Show_Understood += ShowUnderstood;
        GLOBAL.instance.M_event.EVT_Hide_Understood += HideUnderstood;
    }

    void OnDisplayDialogue(string text) {
        //Debug.Log("Triggered OnDIsplayDialogue");
        dialogueText.text = text;
      
    }

    void ShowDialogue() {
        //Debug.Log("Triggered ShowDialogue");
        GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        GetComponent<CanvasGroup>().interactable = true;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void HideDialogue() {
       // Debug.Log("Triggered Hide Dialogue");
        GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        GetComponent<CanvasGroup>().DOFade(0, 0.5f);
        GetComponent<CanvasGroup>().interactable = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    void ShowUnderstood() {
       // Debug.Log("Show Understood");
        understoodParent.DOFade(1, 0.5f);
        understoodParent.interactable = true;
        understoodParent.blocksRaycasts = true;
    }

    void HideUnderstood() {
       // Debug.Log("Hide Understood");
        understoodParent.DOFade(0, 0.5f);
        understoodParent.interactable = false;
        understoodParent.blocksRaycasts = false;
    }

    void ShowPlayAgain() {
        playAgainParent.DOFade(1, 0.5f);
        playAgainParent.interactable = true;
        playAgainParent.blocksRaycasts = true;
    }

    void HidePlayAgain() {
        playAgainParent.DOFade(0, 0.5f);
        playAgainParent.interactable = false;
        playAgainParent.blocksRaycasts = false;
    }

    void Initialize() {
        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<CanvasGroup>().interactable = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        playAgainParent.alpha = 0;
        playAgainParent.interactable = false;
        playAgainParent.blocksRaycasts = false;
        understoodParent.alpha = 0;
        understoodParent.interactable = false;
        understoodParent.blocksRaycasts = false;
    }

    public void HidePopups() {
        HidePlayAgain();
        HideUnderstood();
    }
}
