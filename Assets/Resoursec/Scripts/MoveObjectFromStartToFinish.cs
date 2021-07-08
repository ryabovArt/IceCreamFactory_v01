using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveObjectFromStartToFinish : MonoBehaviour
{

    // абстрактный класс для определения движения сущностей

    private float speed;
    protected Transform endPoint;

    void Start()
    {
        speed = GameManager.instance.DispenserSpeed;
        SetEndPoint();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);
    }

    public abstract void SetEndPoint();
}
