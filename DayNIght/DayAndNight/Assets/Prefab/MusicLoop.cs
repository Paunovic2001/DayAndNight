using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip loop;
    public bool dontDestroyOnLoad = false;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = loop;
    }

    private void Update()
    {
        audioSource.volume = PlayerPrefs.GetFloat("musicVolume");
    }
}