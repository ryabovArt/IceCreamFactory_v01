using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellAd : MonoBehaviour
{
    public GameObject Main, Slider, Video, Unknown;

    bool check = true;

    public void ExampleFunc()
    {
        if (check)
        {
            Main.SetActive(true);
            Slider.SetActive(true);
            Video.SetActive(true);
            Unknown.SetActive(false);
            check = false;
        }
        else
        {
            Main.SetActive(false);
            Slider.SetActive(false);
            Video.SetActive(false);
            Unknown.SetActive(true);
            check = true;
        }
    }
}
