using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static readonly string VOLUME = "volume";
    private static AudioSource audioSource;

    public static float Volume
    {
        get { return PlayerPrefs.GetFloat(VOLUME, 0.1f); }
        set { PlayerPrefs.SetFloat(VOLUME, value); audioSource.volume = PlayerPrefs.GetFloat(VOLUME, 0.1f); }
    }

    private void Start()
    {
        StartComponents();
    }

    private void StartComponents()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.playOnAwake = true;
        audioSource.volume = Volume;
        audioSource.loop = true;
    }
}
