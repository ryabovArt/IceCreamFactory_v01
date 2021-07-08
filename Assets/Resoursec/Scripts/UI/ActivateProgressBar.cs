using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateProgressBar : MonoBehaviour
{
    [SerializeField] private GameObject[] progressBars;

    private void Start()
    {
        Activate();
    }

    private void OnEnable()
    {
        MoveDispenser.getEndPoint += StartFilling;
    }

    private void OnDisable()
    {
        MoveDispenser.getEndPoint -= StartFilling;
    }

    /// <summary>
    /// Активируем прогрессбары в зависимости от уровня
    /// </summary>
    public void Activate()
    {
        for (int i = 0; i < GameManager.instance.dispenserCountInLevel; i++)
        {
            progressBars[i].SetActive(true);
        }
    }

    /// <summary>
    /// Заполнение бара
    /// </summary>
    public void StartFilling()
    {
        if (MoveDispenser.index <= GameManager.instance.dispenserCountInLevel)
        {
            progressBars[MoveDispenser.index - 1].GetComponent<LevelProgressBar>().enabled = true;
        }
    }
}
