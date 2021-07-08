using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressBar : MonoBehaviour
{
    [SerializeField] private Image bar;

    private float fill;
    private bool isStartFill;

    void Start()
    {
        fill = 0.1f;
        print(fill);
    }

    /// <summary>
    /// Заполняем прогресс бар
    /// </summary>
    void FixedUpdate()
    {
        fill += Time.deltaTime * 0.2f;
        bar.fillAmount = fill;
    }
}
