using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FortuneWheel : MonoBehaviour
{
    public CoinsCount coins;

    private int numberOfTurns;
    private int whatWeWin;

    private float speed;

    public bool isCanTurn;

    [SerializeField] private Text winText;
    [SerializeField] private Text timeToBonus;

    TimeSpan timeSpan;

    private DateTime timerEnd;

    TimeSpan delta;


    void Start()
    {
        isCanTurn = true;
        //timerEnd = DateTime.Now.AddMinutes(240);
        //CheckOffline();
        //timerEnd = DateTime.Now.AddMinutes(240 - (timeSpan.Minutes));
        print("timeSpan.Minutes " + timeSpan.Minutes);
    }

    public void CheckOffline()
    {
        if (PlayerPrefs.HasKey("LastSession"))
        {
            timeSpan = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString("LastSession"));
            print(string.Format("вас не было: {0} дней, {1} часов, {2} минут, {3} секунд",
                timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds));

            if (/*timeSpan.Days >= 0 && timeSpan.Hours >= 4*/timeSpan.Seconds > 30)
            {
                isCanTurn = true;
            }
            if (/*timeSpan.Days == 0 && timeSpan.Hours < 4*/timeSpan.Seconds < 30)
            {
                isCanTurn = false;
            }
        }
        PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
    }

    private void Update()
    {
        //delta = timerEnd - DateTime.Now;
        //Debug.Log(delta.Hours.ToString("00") + ":" + delta.Minutes.ToString("00"));
        //timeToBonus.text = delta.Hours.ToString() + ":" + delta.Minutes.ToString() + ":" + delta.Seconds.ToString();
        //if (delta.TotalHours <= 0 && delta.TotalMinutes <= 0)
        //{
        //    Debug.Log("The END");
        //}
    }

    /// <summary>
    /// Запускаем колесо фортуны
    /// </summary>
    public void TaskOnClick()
    {
        print(isCanTurn);
        if (isCanTurn)
        {
            StartCoroutine(TurnTheWheel());
            isCanTurn = false;
        }
        //StartCoroutine(TurnTheWheel());
    }

    public void TurnWheelAfrerAdvertisement()
    {
        StartCoroutine(TurnTheWheel());
    }

    IEnumerator TurnTheWheel()
    {
        isCanTurn = false;

        numberOfTurns = UnityEngine.Random.Range(30, 50);

        speed = 0.01f;

        for (int i = 0; i < numberOfTurns; i++)
        {
            transform.Rotate(0, 0, 22.5f);

            if (i > Mathf.Round(numberOfTurns * 0.5f))
            {
                speed = 0.02f;
            }
            if (i > Mathf.Round(numberOfTurns * 0.7f))
            {
                speed = 0.07f;
            }
            if (i > Mathf.Round(numberOfTurns * 0.9f))
            {
                speed = 0.1f;
            }

            yield return new WaitForSeconds(speed);
        }

        if (Mathf.RoundToInt(transform.eulerAngles.z) % 45 != 0)
        {
            transform.Rotate(0, 0, 22.5f);
        }

        whatWeWin = Mathf.RoundToInt(transform.eulerAngles.z);

        switch (whatWeWin)
        {
            case 0 :
                winText.text = "рецепт";
                // что добавляется
                break;
            case 45:
                winText.text = "15";
                PlayerPrefs.SetInt("CoinsCount", coins.coinsCount += 15);
                // что добавляется
                break;
            case 90:
                winText.text = "5";
                PlayerPrefs.SetInt("CoinsCount", coins.coinsCount += 5);
                // что добавляется
                break;
            case 135:
                winText.text = "30";
                PlayerPrefs.SetInt("CoinsCount", coins.coinsCount += 30);
                // что добавляется
                break;
            case 180:
                winText.text = "10";
                PlayerPrefs.SetInt("CoinsCount", coins.coinsCount += 10);
                // что добавляется
                break;
            case 225:
                winText.text = "рецепт";
                // что добавляется
                break;
            case 270:
                winText.text = "40";
                PlayerPrefs.SetInt("CoinsCount", coins.coinsCount += 40);
                // что добавляется
                break;
            case 360:
                winText.text = "20";
                PlayerPrefs.SetInt("CoinsCount", coins.coinsCount += 20);
                // что добавляется
                break;
        }

        coins.coinsCountText.text = PlayerPrefs.GetInt("CoinsCount").ToString();

        //isCanTurn = true; // !!!
    }
}
