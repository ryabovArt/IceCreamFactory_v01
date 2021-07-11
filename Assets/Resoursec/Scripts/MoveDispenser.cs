using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDispenser : MoveObjectFromStartToFinish
{
    public static event Action OnMiss;
    public static event Action getEndPoint;

    public Transform stopPoint;

    public static int index;
    

    public override void SetEndPoint()
    {
        endPoint = GameManager.instance.SpawnPoint;
        StartCoroutine(ChangeEndPoint());
    }

    /// <summary>
    /// Действия при достижении дозатором левого края за игровым полем
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndPoint"))
        {
            index++;
            print("MoveDispenser.index " + index);

            getEndPoint?.Invoke();
            var forDestroy = GameObject.FindGameObjectsWithTag("IceCream");

            for (int i = 0; i < forDestroy.Length; i++)
            {
                if (Vector3.Distance(gameObject.transform.position, forDestroy[i].transform.position) < 3f)
                {
                    Destroy(forDestroy[i].gameObject);
                }
            }

            Destroy(gameObject);
        }
        if (other.CompareTag("FinishUpperPoint"))
        {
            OnMiss?.Invoke();
        }
        if (other.CompareTag("DoTap"))
        {
            if (GameManager.instance.level == 1 && GameManager.instance.numberOfGamesPlayed == 0)
            {
                GameManager.instance.GetComponent<InstantiateIceCream>().button.interactable = true;
                GameManager.instance.doTapText.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    IEnumerator ChangeEndPoint()
    {
        yield return new WaitForSeconds(0.5f);
        endPoint = GameManager.instance.DestroyPoint;
    }

    /// <summary>
    /// Останавливаем дозатор
    /// </summary>
    public void StopDispenser()
    {
        StartCoroutine(StopDis());
    }

    IEnumerator StopDis()
    {
        SpawnNuts.isSpawnNuts = true;
        stopPoint = gameObject.transform;
        endPoint = stopPoint;
        yield return new WaitForSeconds(0.3f);
        SpawnNuts.isSpawnNuts = false;
        endPoint = GameManager.instance.DestroyPoint;
    }
}
