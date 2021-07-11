using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePlayerPrefs : MonoBehaviour
{
    public void Del()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey("Level");
        PlayerPrefs.SetInt("Level", 1);
    }
}
