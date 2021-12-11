using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static bool instantiated;

    public AudioSource asMenuMusic, asLevelMusic;
    public AudioSource sfxLevelWin, sfxPlayerDeath, sfxKeyCollect;

    private float musicVolume = 0.0f;
    private float sfxVolume = 0.0f;

    private void Awake()
    {
        if (instantiated)
        {
            Destroy(gameObject);
        }
        else
        {
            instantiated = true;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayLevelWinSFX()
    {
        sfxLevelWin.Play();
    }

    public void PlayPlayerDeathSFX()
    {
        sfxPlayerDeath.Play();
    }

    public void PlayKeyCollectSFX()
    {
        sfxKeyCollect.Play();
    }

    public void SetMusicVolume(float value)
    {
        musicVolume = value;
        asMenuMusic.volume = musicVolume;
        asLevelMusic.volume = musicVolume;
    }

    public void SetSFXVolume(float value)
    {
        sfxVolume = value;
        sfxLevelWin.volume = sfxVolume;
        sfxPlayerDeath.volume = sfxVolume;
        sfxKeyCollect.volume = sfxVolume;
    }

    public void PlayMenuMusic()
    {
        asLevelMusic.Stop();
        if (!asMenuMusic.isPlaying) { asMenuMusic.Play(); }
    }

    public void PlayLevelMusic()
    {
        asMenuMusic.Stop();
        if (!asLevelMusic.isPlaying) { asLevelMusic.Play(); }
    }
}
