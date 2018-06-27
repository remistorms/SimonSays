using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour {

	public void ClickedOnPlayButton()
    {
        Debug.Log("Clicked on Play button");
        GetComponent<Image>().color = new Color(Random.value, Random.value, Random.value);
        GLOBAL.instance.M_event.Fire_EVT_Game_Setup();
    }
}
