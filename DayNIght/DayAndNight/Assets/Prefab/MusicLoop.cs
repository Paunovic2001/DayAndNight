using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicLoop : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip loop;
    public bool dontDestroyOnLoad = false;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = loop;
        audioSource.Play();
    }

    private void Update()
    {
        audioSource.volume = PlayerPrefs.GetFloat("musicVolume");
        if (SceneManager.GetActiveScene().name == "Main_menu" && audioSource.isPlaying == true)
        {
            audioSource.Pause();
        }
        else if(SceneManager.GetActiveScene().name != "Main_menu" && audioSource.isPlaying == false)
        {
            audioSource.Play();
        }
    }
}