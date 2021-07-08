using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateIceCream : MonoBehaviour
{
    /// <summary>
    /// ������� ���������, ������� ��� ������� �� ��������
    /// </summary>
    public void InstantiateIce()
    {
        if (GameManager.instance.dispenser != null)
        {
            GameManager.instance.dispenser.GetComponent<SpawnIceCream>().Spawn();
        }
    }
}
