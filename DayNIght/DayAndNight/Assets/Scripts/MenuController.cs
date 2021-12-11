using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject winMenu;

    public GameObject inGameMusicLoop;

    bool pauseOn;

    public Slider musicSlider;
    public Text musicSliderText;
    public Slider audioSlider;
    public Text audioSliderText;

    public AudioSource audioAS;

    private AudioManager am;

    private void Start()
    {
        am = FindObjectOfType<AudioManager>();

        if (!PlayerPrefs.HasKey("musicVolume")) { PlayerPrefs.SetFloat("musicVolume", 1.0f); }
        if (!PlayerPrefs.HasKey("audioVolume")) { PlayerPrefs.SetFloat("audioVolume", 1.0f); }

        am.PlayMenuMusic();

        Time.timeScale = 1f;
        
        LoadVolume();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            PlayerPrefs.SetInt("thisLevel", 99999);
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            PlayerPrefs.DeleteAll();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void InstantiateMusic()
    {
        am.PlayLevelMusic();
        //var loop = Instantiate(inGameMusicLoop);
        //loop.GetComponent<AudioSource>().Play();
        //DontDestroyOnLoad(loop);
    }

    public void ApplicationQuit()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void Pause()
    {
        if (pauseOn == true)
        {
            pauseOn = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            pauseOn = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void PauseOnWin()
    {

        pauseOn = false;
        winMenu.SetActive(true);
        Time.timeScale = 0f;


    }

    public void PauseButton()
    {
        if (pauseOn == true)
        {
            pauseOn = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            pauseOn = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ResumeTime()
    {
        Time.timeScale = 1f;
    }

    public void MusicSlider(float volume)
    {
        musicSliderText.text = volume.ToString("0.0");
        PlayerPrefs.SetFloat("musicText", volume);

        am.SetMusicVolume(volume);
    }

    public void AudioSlider(float volume)
    {
        audioSliderText.text = volume.ToString("0.0");
        PlayerPrefs.SetFloat("audioText", volume);

        am.SetSFXVolume(volume);
    }

    public void SaveVolume()
    {
        float music = musicSlider.value;
        float audio = audioSlider.value;
        PlayerPrefs.SetFloat("musicVolume", music);
        PlayerPrefs.SetFloat("audioVolume", audio);
        LoadVolume();
    }

    void LoadVolume()
    {
        float music = PlayerPrefs.GetFloat("musicVolume");
        float audio = PlayerPrefs.GetFloat("audioVolume");

        am.SetMusicVolume(music);
        am.SetSFXVolume(audio);

        if (musicSlider) { musicSlider.value = music; }
        if (audioSlider) { audioSlider.value = audio; }

        if (audioAS) { audioAS.volume = audio; }
    }
}
