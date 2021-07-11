using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateIceCream : MonoBehaviour
{
    [SerializeField] private GameObject doTap;
    public Button button;

    private void Start()
    {
        if (GameManager.instance.level == 1 && GameManager.instance.numberOfGamesPlayed == 0)
        {
            button.interactable = false;
        }
    }

    /// <summary>
    /// Спавним мороженое, посыпку или поливку из дозатора
    /// </summary>
    public void InstantiateIce()
    {
        if (GameManager.instance.dispenser != null)
        {
            GameManager.instance.dispenser.GetComponent<SpawnIceCream>().Spawn();
        }
    }

    public void SetTimeScale()
    {
        if (Time.timeScale == 0)
        {
            HideTapText();
            Time.timeScale = 1;
            Destroy(doTap.gameObject);
        }
    }

    public void HideTapText()
    {
        GameManager.instance.doTapText.SetActive(false);
    }
}
