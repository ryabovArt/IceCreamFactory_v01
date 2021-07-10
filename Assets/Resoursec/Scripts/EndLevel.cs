using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public static event Action endLevel;

    /// <summary>
    /// ƒействи€, когда дозатор вышел за левую часть пол€
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            StartCoroutine(DelayBeforeChangingTheScene());
        }
    }

    IEnumerator DelayBeforeChangingTheScene()
    {
        endLevel?.Invoke();

        GameManager.instance.numberOfGamesPlayed++;
        PlayerPrefs.SetInt("NumberOfGamesPlayed", GameManager.instance.numberOfGamesPlayed);

        yield return new WaitForSeconds(5f);

        if (GameManager.instance.numberOfGamesPlayed % 10 == 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("WaffleCone"));
            SceneManager.LoadScene("NewVarietyOfIceCream");
        }
        else
        {
            if (GameManager.staticLevel == 0)
            {
                Destroy(GameObject.FindGameObjectWithTag("WaffleCone"));
                SceneManager.LoadScene("Lose");
            }
            if (GameManager.staticLevel > 0)
            {
                SceneManager.LoadScene("Win");
            }
        }
    }
}
