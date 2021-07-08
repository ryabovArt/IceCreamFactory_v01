using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxActions : MonoBehaviour
{
    [SerializeField] private GameObject camera;

    [SerializeField] private Animator boxAnimator;

    void Start()
    {
        //boxAnimator = GetComponent<Animator>();
    }

    public void PlayBoxAnimation()
    {
        boxAnimator.SetTrigger("CloseBox");
    }

    public void PlayBoxAnimation2()
    {
        boxAnimator.SetTrigger("CloseBox2");
    }

    public void ChangeTarget()
    {
        camera.GetComponent<CamRotate>().target = gameObject;
    }
}
