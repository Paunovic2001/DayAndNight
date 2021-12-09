using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCheck : MonoBehaviour
{
    public bool dayOnPortal = false;
    public bool nightOnPortal = false;
    bool endOfGame = false;
    MenuController mc;

    private void Start()
    {
        mc = FindObjectOfType<MenuController>();
    }

    private void Update()
    {
        if (dayOnPortal == true && nightOnPortal == true && endOfGame == false)
        {
            //play a sound 
            Debug.Log("Level end");
            mc.PauseOnWin();
            endOfGame = true;
        }
    }
}
