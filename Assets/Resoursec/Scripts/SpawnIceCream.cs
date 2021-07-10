using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnIceCream : MonoBehaviour
{
    [SerializeField] private List<IceCreamData> iceCreamData = new List<IceCreamData>();

    [SerializeField] private List<Texture> textures = new List<Texture>();

    public Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    /// <summary>
    /// Спавним из дозатора мороженое, топпинг или посыпку
    /// </summary>
    public void Spawn()
    {
        if (gameObject.CompareTag("Dispenser"))
        {
            var go = Instantiate(iceCreamData[GameManager.instance.dispenserIndex - 1].prefab, gameObject.transform.position, Quaternion.identity);
            //go.GetComponent<MeshRenderer>().material.mainTexture = textures[GameManager.instance.dispenserIndex - 1];
            go.GetComponent<Renderer>().material.SetTexture("_texture", textures[GameManager.instance.dispenserIndex - 1]);
            GetComponentInChildren<DoseIceCream>().Dose();
        }
        if (gameObject.CompareTag("Topping"))
        {
            transform.GetChild(2).GetComponent<ParticleSystem>().Play();
        }
        if (gameObject.CompareTag("Nuts"))
        {
            GetComponent<MoveDispenser>().StopDispenser();
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Спавним первые 2 шарика мороженого
    /// </summary>
    public void SpawnFirstIceCream()
    {
        var go = Instantiate(iceCreamData[GameManager.instance.dispenserIndex - 1].prefab, gameObject.transform.position, Quaternion.identity);
        //go.GetComponent<MeshRenderer>().material.mainTexture = textures[GameManager.instance.dispenserIndex - 1];
        go.GetComponent<Renderer>().material.SetTexture("_texture", textures[GameManager.instance.dispenserIndex - 1]);
    }
}
