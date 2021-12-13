using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonationScript : MonoBehaviour
{
    public void OpenURL()
    {
        Application.OpenURL("https://jovvvva.itch.io/night-day/purchase");
        Debug.Log("Works?");
    }
}
