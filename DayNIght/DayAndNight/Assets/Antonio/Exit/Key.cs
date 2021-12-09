using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{ 
    //ovo ide na JEBENI key

    GameObject door;
    public Sprite doorOn;
    [Header("True = day, false = night")]
    public bool dayOrNight = true;
    private void Start()
    {
        if(dayOrNight == true)
        {
            door = GameObject.FindGameObjectWithTag("Door" + "Day");
        }
        else
        {
            door = GameObject.FindGameObjectWithTag("Door" + "Night");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerDay" || collision.tag == "PlayerNight")
        {
            door.GetComponent<ExitDoor>().isUnlocked = true;
            door.GetComponent<SpriteRenderer>().sprite = doorOn;
            this.gameObject.SetActive(false);
        }
    }
}
