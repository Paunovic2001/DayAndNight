using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button[] levelButtons;

    private void Start()
    {
        int thisLevel = PlayerPrefs.GetInt("thisLevel", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > thisLevel)
            {
                levelButtons[i].interactable = false;
                
                if (levelButtons[i].interactable == false)
                {
                    levelButtons[i].GetComponent<Image>().color = Color.gray;
                }
            }
        }
    }
}
