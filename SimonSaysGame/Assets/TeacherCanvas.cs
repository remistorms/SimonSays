using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class TeacherCanvas : MonoBehaviour {

    public static TeacherCanvas instance;
    public TextMeshProUGUI paternLabel;
    public CanvasGroup canvasGroup;
    RectTransform rectTransform;
    Vector3 originalScale;

    private void Start()
    {
        instance = this;
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
        rectTransform.localScale = Vector3.zero;
        GLOBAL.instance.M_event.EVT_Presentation_Start += OnPresentationStart;
        GLOBAL.instance.M_event.EVT_Presentation_Finished += OnPresentationFinished;
        GLOBAL.instance.M_event.EVT_Game_Setup += OnGameSetup;
        paternLabel.text = "";
        canvasGroup.alpha = 0;

    }

    public void DisplayTeacherCanvas() {
        canvasGroup.DOFade(1, 0.25f );
        rectTransform.DOScale(originalScale.x, 0.25f);

    }

    public void HideTeacherCanvas()
    {
        canvasGroup.DOFade(0, 0.25f);
        rectTransform.DOScale(0, 0.25f);

    }

    void OnPresentationStart() {
        
    }

    void OnGameSetup() {
        canvasGroup.DOFade(1, 0.2f);
    }

    void OnPresentationFinished() {
        canvasGroup.DOFade(0, 0.2f);
    }

    public void ShowTeacherLongDialogue(Node[] nodes) {
        StartCoroutine(TeacherFirstDialogue(nodes));
    }

    public void ShowTeacherShortDialogue()
    {
        StartCoroutine(TeacherShortDialogue());
    }

    public void ShowTeacherSecondDialogue()
    {
        StartCoroutine(TeacherSecondDialogue());
    }

    //7 seconds
    IEnumerator TeacherFirstDialogue(Node[] nodes) {
        DisplayTeacherCanvas();
        yield return new WaitForSeconds(1);
        paternLabel.text = "Pay attention kids...";
        yield return new WaitForSeconds(3);
        paternLabel.text = "...remember the sequence....";
        yield return new WaitForSeconds(3);
        paternLabel.text = "...";
        yield return new WaitForSeconds(1);

        //Display Numbers First
        for (int i = 0; i < nodes.Length; i++)
        {
            string realString = nodes[i].nodeID.ToString();
            realString = realString.Substring(1);
            int myInt = int.Parse(realString);
            myInt = myInt + 1;
            paternLabel.text = myInt.ToString();
            yield return new WaitForSeconds(1f);
            paternLabel.text = "";
            yield return new WaitForSeconds(0.5f);
        }

        //Activate Validator
        Validator.instance.Activate(nodes);
    }

    //3 seconds
    IEnumerator TeacherShortDialogue()
    {
        DisplayTeacherCanvas();
        yield return new WaitForSeconds(1);
        paternLabel.text = "...next sequence...";
        yield return new WaitForSeconds(1.5f);
        paternLabel.text = "...";
        yield return new WaitForSeconds(0.5f);
    }

    //2 seconds
    IEnumerator TeacherSecondDialogue()
    {
        //Second Dialogue
        paternLabel.text = "Now it's your turn...";
        yield return new WaitForSeconds(1.5f);
        HideTeacherCanvas();
        yield return new WaitForSeconds(0.5f);
    }

    
}
