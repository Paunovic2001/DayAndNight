using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCheck : MonoBehaviour
{
    public bool dayOnPortal = false;
    public bool nightOnPortal = false;
    bool endOfGame = false;

    private void Update()
    {
        if (dayOnPortal == true && nightOnPortal == true && endOfGame == false)
        {
            Debug.Log("Level end");
            FindObjectOfType<LevelMenu>().OnWin();
            FindObjectOfType<AudioManager>().PlayLevelWinSFX();
            endOfGame = true;
            PlayerPrefs.SetInt("thisLevel", SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
