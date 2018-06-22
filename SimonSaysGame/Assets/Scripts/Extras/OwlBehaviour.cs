using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlBehaviour : MonoBehaviour {

    public Animator owlAnimator;
    public AudioSource owlAudioSource;

    public void OwlJump() {
        owlAnimator.SetTrigger("jump");
        owlAudioSource.Play();
    }
}
