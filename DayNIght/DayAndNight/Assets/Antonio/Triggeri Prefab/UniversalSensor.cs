using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UniversalSensor : MonoBehaviour
{
    [Header("Possible types: " + "\"door\"" + "\"spike\"" + ", \"platform\"" + ", \"saw\"")]
    public string type;
    [Header("Possible tags: " + "\"PlayerDay\"" + ", \"PlayerNight\"")]
    public string characterTag;
    public GameObject doorOrPlatform;
    public bool stayTurnedOn = false;
    [HideInInspector]public bool activated = false;
    LighManager lm;
    [Header("VARIABLES USED ONLY FOR SAW")]
    public bool spin = true;
    public bool enableOnExit = true;

    private void Start()
    {
        lm = GetComponent<LighManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == characterTag)
        {
            other.GetComponent<SFXAudio>().Trigger();
            if (type == "door")
            {
                if (doorOrPlatform.GetComponent<DoorController>().isOpened == false)
                {
                    doorOrPlatform.GetComponent<DoorController>().stayOpen = stayTurnedOn;
                    doorOrPlatform.GetComponent<DoorController>().OpenDoor();
                }
            }
            if (type == "spike")
            {
                if (doorOrPlatform.GetComponent<SpikesScript>().isOpened == false)
                {
                    doorOrPlatform.GetComponent<SpikesScript>().stayOpen = stayTurnedOn;
                    doorOrPlatform.GetComponent<SpikesScript>().MoveBladeTo();
                }
            }
            if (type == "platform")
            {
                doorOrPlatform.GetComponent<PlatformController>().isMoving = true;
            }
            if (type == "saw")
            {
                //if (doorOrPlatform.GetComponent<SawsMove>().isOpened == false)
                //{
                    doorOrPlatform.GetComponent<SawsMove>().stayOpen = stayTurnedOn;
                    doorOrPlatform.GetComponent<SawsMove>().MoveBladeTo();
                    if(spin == false)
                    {
                        doorOrPlatform.GetComponent<SawsMove>().StopSpinning();
                    }
                //}
            }
            lm.Show(other.tag);
            activated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == characterTag)
        {
            other.GetComponent<SFXAudio>().Trigger();
            if (type == "door")
            {
                if (stayTurnedOn == false)
                {
                    doorOrPlatform.GetComponent<DoorController>().CloseDoor();
                }
            }
            if (type == "spike")
            {
                if (stayTurnedOn == false)
                {
                    doorOrPlatform.GetComponent<SpikesScript>().MoveBladeFrom();
                }
            }
            if (type == "platform" && stayTurnedOn == false)
            {
                doorOrPlatform.GetComponent<PlatformController>().isMoving = false;
            }
            if (type == "saw")
            {
                if (stayTurnedOn == false)
                {
                    doorOrPlatform.GetComponent<SawsMove>().MoveBladeFrom();
                }
                if (enableOnExit)
                {
                    doorOrPlatform.GetComponent<SawsMove>().enableOnReturn = true;
                }
            }
            if (stayTurnedOn == false)
            {
                lm.Hide(other.tag);
            }

            Debug.Log(activated);
        }
    }
}
