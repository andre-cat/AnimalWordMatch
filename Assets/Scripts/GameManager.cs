using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource _musicAudioSource;
    [SerializeField] private AudioSource _voiceAudioSource;

    private static readonly string VOLUME = "volume";

    private static AudioSource musicAudioSource;
    private static AudioSource voiceAudioSource;

    private static bool gameOver;

    public static bool GameOver
    {
        get => gameOver;
        set => gameOver = value;
    }

    public static float Volume
    {
        get { return PlayerPrefs.GetFloat(VOLUME, 0.1f); }
        set
        {
            PlayerPrefs.SetFloat(VOLUME, value);
            musicAudioSource.volume = PlayerPrefs.GetFloat(VOLUME, 0.1f);
        }
    }

    public delegate void GameOverDelegate();

    public static GameOverDelegate gameOverEvent;

    private void Start()
    {
        StartComponents();
    }

    private void FixedUpdate()
    {
        SetVoiceVolume();

        if (gameOver)
        {
            gameOver = false;
            gameOverEvent();
        }
    }

    private void StartComponents()
    {

        musicAudioSource = _musicAudioSource;
        musicAudioSource.playOnAwake = true;
        musicAudioSource.volume = Volume;
        musicAudioSource.loop = true;

        voiceAudioSource = _voiceAudioSource;
        voiceAudioSource.playOnAwake = false;
        voiceAudioSource.volume = Volume;
        voiceAudioSource.loop = false;
    }

    private void SetVoiceVolume()
    {
        voiceAudioSource.volume = musicAudioSource.volume * 200 / 100;
    }

}