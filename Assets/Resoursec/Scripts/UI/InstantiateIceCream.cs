using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateIceCream : MonoBehaviour
{
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
}
