using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXAudio : MonoBehaviour
{
    AudioSource audiosource;

    public AudioClip footstep;
    public AudioClip jump;
    public AudioClip trigger;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.loop = false;
        audiosource.playOnAwake = false;
    }

    private void Update()
    {
        audiosource.volume = PlayerPrefs.GetFloat("audioText");
    }
    public void FootStep()
    {
        audiosource.clip = footstep;
        audiosource.Play();
    }

    public void Jump()
    {
        audiosource.clip = jump;
        audiosource.Play();
    }

    public void Trigger()
    {
        audiosource.clip = trigger;
        audiosource.Play();
    }
}
