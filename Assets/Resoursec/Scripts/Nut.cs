using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;

    /// <summary>
    /// Прилипание посыпки в верхнему мороженому на рожке
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (/*other.CompareTag("Player")*/other.CompareTag("IceCream"))
        {
            print("other.transform.position " + other.transform.position);
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            gameObject.GetComponent<Transform>().parent = other.transform;
        }
    }
}
