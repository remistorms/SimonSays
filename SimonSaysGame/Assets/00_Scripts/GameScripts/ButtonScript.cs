using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonScript : MonoBehaviour {

    public int buttonID;
    public Animator buttonAnimator;
    public AudioSource buttonAudioSource;
    public SkinnedMeshRenderer buttonMeshToColor;
    public Color pressedColor, unpressedColor;

    private void Start()
    {
        //Gets the corresponding sound from sound manager
        //buttonAudioSource.clip = SoundManager.instance.musicNotes[buttonID];
        buttonMeshToColor.material.color = unpressedColor;
    }

    //Main method button clicked here I add or remove behaviours on the button
    public void ButtonClicked() {

        GLOBAL.instance.M_event.Fire_EVT_Button_Pushed(buttonID);
        ButtonAnimation();
        PlayButtonSound();
        StartCoroutine(ColorChange());
        
    }

    //Animates the button up and down state animator
     void ButtonAnimation() {
        buttonAnimator.SetTrigger("ButtonPress");
    }

    //Plays the corresponding sound
     void PlayButtonSound() {
        buttonAudioSource.Play();
    }

    //Changes color when pressed and goes back to normal
    IEnumerator ColorChange() {
        buttonMeshToColor.material.DOColor(pressedColor, 0.1f);
        yield return new WaitForSeconds(0.1f);
        buttonMeshToColor.material.DOColor(unpressedColor, 0.1f);
    }

}
