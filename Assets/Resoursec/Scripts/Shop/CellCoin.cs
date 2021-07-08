using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCoin : MonoBehaviour
{
    public GameObject Main, Coin, Price, Unknown;

    bool check = true;

    public void ExampleFunc()
    {
        if (check)
        {
            Main.SetActive(true);
            Coin.SetActive(true);
            Price.SetActive(true);
            Unknown.SetActive(false);
            check = false;
        }
        else
        {
            Main.SetActive(false);
            Coin.SetActive(false);
            Price.SetActive(false);
            Unknown.SetActive(true);
            check = true;
        }
    }
}
