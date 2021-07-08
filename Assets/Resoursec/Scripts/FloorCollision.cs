using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FloorCollision : MonoBehaviour
{
    private Collider go;

    [SerializeField] private Animator iceCreamAnimator;

    [SerializeField] private Effects effects;

    public static bool isCollisionWithFloor;

    /// <summary>
    /// Если мороженое упало на пол
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IceCream"))
        {
            if (isCollisionWithFloor == false) isCollisionWithFloor = true;
            
            go = other;

            effects.SetSadSmile();
            StartCoroutine(FreezeLowerIceCream());
        }
    }

    IEnumerator FreezeLowerIceCream()
    {
        yield return new WaitForSeconds(0.3f);
        go.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
}
