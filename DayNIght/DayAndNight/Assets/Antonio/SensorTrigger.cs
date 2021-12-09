using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorTrigger : MonoBehaviour
{
    public bool stayTurnedOn = false;
    public GameObject platform;
    public PlatformController pc;
    private void Start()
    {
        pc = platform.GetComponent<PlatformController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TRIGGERED" + other.tag);
        if (other.tag == "PlayerDay")
        {
            pc.isMoving = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "PlayerDay")
        {
            pc.isMoving = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayerDay")
        {
            if (stayTurnedOn == false)
            {
                pc.isMoving = false;
            }
        }
    }
}
