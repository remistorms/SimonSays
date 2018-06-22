using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StudentCanvas : MonoBehaviour {

    CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void DisplayCanvas() {
        canvasGroup.DOFade(1, 0.5f);
    }

    public void HideCanvas()
    {
        canvasGroup.DOFade(0, 0.5f);
    }
}
