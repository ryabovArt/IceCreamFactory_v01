using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStarsOnWinScene : MonoBehaviour
{
    public GameObject[] stars;
    public GameObject[] cells;
    public GameObject[] crosses;

    private void Start()
    {
        SetStars();
        SetCells();
    }

    /// <summary>
    /// ��������� ������ � ����������� �� ���������� ����������� ������
    /// </summary>
    private void SetStars()
    {
        if (IceCream.isOneStar == true)
        {
            stars[0].SetActive(true);
        }
        if (IceCream.isTwoStar == true)
        {
            stars[1].SetActive(true);
        }
        if (GameManager.instance.SpawnedIceCreame.Count == GameManager.instance.dispenserCountInLevel + 1)
        {
            stars[2].SetActive(true);
        }

        if (GameManager.instance.dispenserCountInLevel == 0 && IceCream.isOneStar == true) // �������� �� ����� ��������
        {
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].SetActive(true);
            }
        }
    }

    /// <summary>
    /// ����������� ������ � ���������, � ����������� �� ���������
    /// </summary>
    private void SetCells()
    {
        for (int i = 1; i < GameManager.instance.dispenserCountInLevel + 1; i++)
        {
            cells[i].SetActive(true);
        }

        for (int i = 0; i < IceCream.indexOfIceCreamInCone.Count; i++)
        {
            crosses[IceCream.indexOfIceCreamInCone[i] - 1].SetActive(false);
        }
    }
}
