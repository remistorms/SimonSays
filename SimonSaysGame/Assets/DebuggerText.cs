using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebuggerText : MonoBehaviour {

    public static DebuggerText instance;
    public TextMeshProUGUI debugText;
	// Use this for initialization
	void Start () {
        instance = this;
	}

    public void Debug(string text) {

        debugText.text = "Debugger Screen: " + text;
    }
}
