using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    
    public Slider musicSlider, sfxSlider;
    public Slider scaleSlider;

    public void UpdateMusicVolume() {
        GLOBAL.instance.M_event.Fire_EVT_Music_Volume_Changed(musicSlider.value);
    }

    public void UpdateSFXVolume()
    {
        GLOBAL.instance.M_event.Fire_EVT_Sfx_Volume_Changed(sfxSlider.value);
    }

    public void UpdateScale()
    {
        GLOBAL.instance.M_event.Fire_EVT_Scale_Changed(scaleSlider.value);
    }
}
