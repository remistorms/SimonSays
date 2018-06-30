using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Manager_Sound : Manager {

    public static Manager_Sound instance;

    public AudioSource backgroundMusicSource;
    public AudioSource fxAudioSource;
    public AudioClip preGameMusic;
    public AudioClip inGameMusic;
    public AudioClip failSound;
    public AudioClip gameOverMusic;
    public AudioClip[] musicNotes;

    private void Start()
    {
        instance = this;
        GLOBAL.instance.M_event.EVT_Game_Start += OnGameStart;
        GLOBAL.instance.M_event.EVT_Game_Over += OnGameOver;
        GLOBAL.instance.M_event.EVT_Game_Setup += OnGameSetup;
        GLOBAL.instance.M_event.EVT_Node_Pressed += OnNodePressed;
        GLOBAL.instance.M_event.EVT_Replay_Game += OnGameStart;
        GLOBAL.instance.M_event.EVT_Music_Volume_Changed += ChangeMusicVolume;
        GLOBAL.instance.M_event.EVT_Sfx_Volume_Changed += ChangeSFXVolume;
    }

    public void OnGameOver() {
        //Debug.Log("Sound Manager OnGameOver");
        backgroundMusicSource.Stop();
        backgroundMusicSource.clip = gameOverMusic;
        backgroundMusicSource.volume = 0.1f;
        backgroundMusicSource.Play();
    }

    void OnGameReplay() {

    }

    void OnNodePressed(Node node) {
        
        fxAudioSource.clip = musicNotes[node.nodeIndex];
        fxAudioSource.Play();
    }

    public void OnGameSetup() {

        backgroundMusicSource.Stop();
        backgroundMusicSource.clip = preGameMusic;
        backgroundMusicSource.volume = 0.5f;
        backgroundMusicSource.Play();
    }

    public void OnGameStart()
    {
        backgroundMusicSource.Stop();
        backgroundMusicSource.clip = inGameMusic;
        backgroundMusicSource.volume = 0.5f;
        backgroundMusicSource.Play();
    }

    IEnumerator GameOverRoutine() {

        fxAudioSource.clip = failSound;
        fxAudioSource.Play();
        backgroundMusicSource.DOFade(0, 0.25f);
        yield return new WaitForSeconds(1f);
        backgroundMusicSource.Stop();
        backgroundMusicSource.volume = 0.1f;
        backgroundMusicSource.clip = gameOverMusic;
        backgroundMusicSource.Play();
    }

    public void ChangeMusicVolume(float volume) {
        backgroundMusicSource.volume = volume;
    }

    public void ChangeSFXVolume(float volume)
    {
        fxAudioSource.volume = volume;
    }
}
