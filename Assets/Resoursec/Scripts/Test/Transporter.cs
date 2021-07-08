using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour
{
    [SerializeField] private Transform endPoint;

    [SerializeField] private Transform begin;
    public Transform Begin { get => begin; }

    [SerializeField] private Transform end;
    public Transform End { get => end; }

    [SerializeField] private float speed;

    void Start()
    {
        //endPoint = GameManager.instance.DestroyPoint;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);
    }
}
