using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighManager : MonoBehaviour
{
    public GameObject light;
    UniversalSensor us;

    private void Start()
    {
        us = GetComponent<UniversalSensor>();
        if (us.characterTag == "PlayerDay")
        {
            light.SetActive(false);
        }
        if (us.characterTag == "PlayerNight")
        {
            light.SetActive(true);
        }
    }

    public void Show(string tag)
    {
        if(tag == "PlayerDay")
        {
            light.SetActive(true);
        }
        if (tag == "PlayerNight")
        {
            light.SetActive(false);
        }
    }
    public void Hide(string tag)
    {
        if(tag == "PlayerDay")
        {
            light.SetActive(false);
        }
        if (tag == "PlayerNight")
        {
            light.SetActive(true);
        }
    }
}
