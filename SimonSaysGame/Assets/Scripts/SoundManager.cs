using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;

    public AudioClip[] musicNotes;
	
    // Use this for initialization
	void Awake () {
        instance = this;
	}
}
