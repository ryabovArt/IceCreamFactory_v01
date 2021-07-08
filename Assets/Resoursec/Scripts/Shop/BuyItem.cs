using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour
{
    public int priceItem;
    public bool isBuy;
    public Sprite itemSkin;
    public GameObject Main, Slider, Video, Unknown;

    void Start()
    {
        
    }

    public void Buy()
    {
        GetComponent<Image>().sprite = itemSkin;
        Unknown.SetActive(false);
        //Main.SetActive(false);
    }
}
