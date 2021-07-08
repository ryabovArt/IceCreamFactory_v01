using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    [SerializeField] private float speed;
    public GameObject target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("WaffleCone");
        target.GetComponent<ChangeDistanceToCamera>().enabled = true;
    }

    void Update()
    {
        transform.RotateAround(target.transform.position, new Vector3(0, 1, 0), speed * Time.deltaTime);
    }

}
