using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    //ovo ide na JEBENI door
    public bool isUnlocked = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "PlayerDay" || collision.tag == "PlayerNight") && isUnlocked == true)
        {
            //play a sound and show "pause" screen
            Debug.Log("Level end");
        }
    }
}
