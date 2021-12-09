using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    //ovo ide na JEBENI door
    public bool isUnlocked = false;
    WinCheck wc;

    private void Start()
    {
        wc = FindObjectOfType<WinCheck>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "PlayerDay" || collision.tag == "PlayerNight") && isUnlocked == true)
        {
            if(collision.tag == "PlayerDay")
            {
                wc.dayOnPortal = true;
            }
            if(collision.tag == "PlayerNight")
            {
                wc.nightOnPortal = true;
            }            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.tag == "PlayerDay" || collision.tag == "PlayerNight") && isUnlocked == true)
        {
            if (collision.tag == "PlayerDay")
            {
                wc.dayOnPortal = false;
            }
            if (collision.tag == "PlayerNight")
            {
                wc.nightOnPortal = false;
            }
        }
    }
}
