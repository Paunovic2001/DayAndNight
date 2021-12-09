using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorText : MonoBehaviour
{
    public Color colorIni = Color.white;
    public Color colorFin = Color.red;
    public float duration = 3f;
    Color lerpedColor = Color.white;

    private float t = 0;
    private bool flag;

    Text _renderer;
    // Use this for initialization
    void Start()
    {
        _renderer = GetComponent<Text>();
    }

    void Update()
    {
        lerpedColor = Color.Lerp(colorIni, colorFin, t);
        _renderer.color = lerpedColor;


        if (flag == true)
        {
            t -= Time.deltaTime / duration;
            if (t < 0.01f)
                flag = false;
        }
        else
        {
            t += Time.deltaTime / duration;
            if (t > 0.99f)
                flag = true;
        }
    }
}
