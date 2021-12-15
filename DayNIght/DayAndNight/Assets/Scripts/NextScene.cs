using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    int nextScene;
    //public void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Player")
    //    {
    //        SceneManager.LoadScene(nextScene);

    //        if(nextScene > PlayerPrefs.GetInt("thisLevel"))
    //        {
    //            PlayerPrefs.SetInt("thisLevel", nextScene);
    //        }
    //    }
    //}

    public void ButtonClickToGoToNextScene()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log(nextScene);
        SceneManager.LoadScene(nextScene);
        if(SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.Log("Win!");
        }
        else if (nextScene > PlayerPrefs.GetInt("thisLevel"))
        {
            //PlayerPrefs.SetInt("thisLevel", nextScene);
        }
    }
}
