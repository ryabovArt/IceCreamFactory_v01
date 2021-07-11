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
            //for (int i = 0; i < IceCream.indexOfIceCreamInCone.Count; i++)
            //{
            //    print("indexOfIceCreamInCone " + IceCream.indexOfIceCreamInCone[i]);
            //}
            StartCoroutine(DelayBeforeChangingTheScene());
        }
    }

    IEnumerator DelayBeforeChangingTheScene()
    {
        endLevel?.Invoke();

        MoveDispenser.index = 0;

        GameManager.instance.numberOfGamesPlayed++;
        PlayerPrefs.SetInt("NumberOfGamesPlayed", GameManager.instance.numberOfGamesPlayed);

        yield return new WaitForSeconds(5f);

        if (GameManager.instance.numberOfGamesPlayed % 10 == 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("WaffleCone"));
            //GameObject.FindGameObjectWithTag("WaffleCone").SetActive(false);
            SceneManager.LoadScene("NewVarietyOfIceCream");
        }
        else
        {
            LoseOrWin();
        }
    }

    public void LoseOrWin()
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
