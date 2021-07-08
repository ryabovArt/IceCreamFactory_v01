using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTabs : MonoBehaviour
{
    public RectTransform[] Buttons;
    public RectTransform[] Tabs;
    public Sprite[] Sprites;
    
    public void Click(int i)
    {
        foreach (RectTransform Button in Buttons)
            Button.GetComponent<Image>().sprite = Sprites[0];
        Buttons[i].GetComponent<Image>().sprite = Sprites[1];
        foreach (RectTransform Tab in Tabs)
            Tab.gameObject.SetActive(false);
        Tabs[i].gameObject.SetActive(true);
    }
}
