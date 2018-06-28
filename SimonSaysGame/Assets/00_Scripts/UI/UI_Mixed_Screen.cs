using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UI_Mixed_Screen : MonoBehaviour {


    public void ActivateScreen() {
        //Debug.Log("Activate " + this.gameObject.name);
        StartCoroutine(ActivateRoutine());
        CenterScreen();
    }

    public void DeactivateScreen() {
       // Debug.Log("Deactivate " + this.gameObject.name);
        StartCoroutine(DeactivateRoutine());
    }

    IEnumerator ActivateRoutine() {
        CanvasGroup myCanvas = GetComponent<CanvasGroup>();
        myCanvas.DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        myCanvas.interactable = true;
        myCanvas.blocksRaycasts = true;
    }

    IEnumerator DeactivateRoutine()
    {
        CanvasGroup myCanvas = GetComponent<CanvasGroup>();
        myCanvas.DOFade(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        myCanvas.interactable = false;
        myCanvas.blocksRaycasts = false;
    }

    public void CenterScreen() {
        GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
}
