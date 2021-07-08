using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Image loadingProgressBar;
    [SerializeField] private GameObject loadingProgressBarParent;

    private void Start()
    {
        StartCoroutine(Delay());
    }

    /// <summary>
    /// Загрузка
    /// </summary>
    /// <returns></returns>
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        SceneTransition.SwichToScene("Lobby");
    }

    void Update()
    {
        loadingProgressBar.fillAmount += Time.deltaTime / 0.2f;
    }
}
