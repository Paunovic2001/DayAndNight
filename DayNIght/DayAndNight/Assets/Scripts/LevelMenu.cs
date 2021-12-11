using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject winMenu;
    public GameObject pauseButton;

    bool paused;

    private void Start()
    {
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);

        SetPaused(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!paused);
            SetPaused(!paused);
        }
    }

    public void SetPaused(bool value)
    {
        paused = value;
        Time.timeScale = paused ? 0.0f : 1.0f;
        //pauseButton.SetActive(!paused);
    }

    public void OnWin()
    {
        SetPaused(true);
        winMenu.SetActive(true);
    }
}
