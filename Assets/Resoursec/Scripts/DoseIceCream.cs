using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoseIceCream : MonoBehaviour
{
    public void Dose()
    {
        transform.localPosition = new Vector3(transform.localPosition.x - 1f, transform.localPosition.y, transform.localPosition.z);
        StartCoroutine(DoseBall());
    }

    IEnumerator DoseBall()
    {
        yield return new WaitForSeconds(0.3f);
        transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
    }
}
