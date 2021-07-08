using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFinish : MoveObjectFromStartToFinish
{
    [SerializeField] private Transform cone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cone"))
        {
            endPoint = gameObject.transform;
        }
    }

    public override void SetEndPoint()
    {
        endPoint = cone;
    }

}
