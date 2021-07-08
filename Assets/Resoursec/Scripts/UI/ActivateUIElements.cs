using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateUIElements : MonoBehaviour
{
    [SerializeField] private GameObject[] cross;
    [SerializeField] private GameObject[] checkMark;
    [SerializeField] private GameObject[] checkPoints;

    private void Start()
    {
        Activate();
    }

    private void OnEnable()
    {
        IceCream.OnHit += IceCreamHit;
        MoveDispenser.OnMiss += FloorHit;
    }

    private void OnDisable()
    {
        IceCream.OnHit -= IceCreamHit;
        MoveDispenser.OnMiss -= FloorHit;
    }


    /// <summary>
    /// ���������� ��������� � ����������� �� ������
    /// </summary>
    public void Activate()
    {
        for (int i = 0; i < GameManager.instance.dispenserCountInLevel; i++)
        {
            checkPoints[i].SetActive(true);
        }
    }

    /// <summary>
    /// ���� �� ������ � �����, ������ �������
    /// </summary>
    private void FloorHit()
    {
        if (MoveDispenser.index < cross.Length && !checkMark[MoveDispenser.index].activeInHierarchy)
        {
            cross[MoveDispenser.index].SetActive(true);
        }
    }

    /// <summary>
    /// ���� ������ � �����, ������ �������
    /// </summary>
    private void IceCreamHit()
    {
        if (MoveDispenser.index < checkMark.Length)
        {
            checkMark[MoveDispenser.index].SetActive(true);
        }
    }
}
