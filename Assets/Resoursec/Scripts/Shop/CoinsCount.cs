using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCount : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;

    void Start()
    {
        coinsCount = PlayerPrefs.GetInt("CoinsCount");
        coinsCountText.text = coinsCount.ToString();
    }
}
