using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneProgressBar : MonoBehaviour
{
    [SerializeField] private LevelChanger levelChanger;

    private Slider slider;

    public float fillSpeed = 0.5f;
    private float targetProgress = 0;

    bool isFade;

    void Start()
    {
        slider = GetComponent<Slider>();
        IncrementProgress(1f);
        
    }


    void Update()
    {
        if (slider.value < targetProgress)
        {
            slider.value += fillSpeed * Time.deltaTime;
        }
        if (slider.value == 1 && isFade == false)
        {
            isFade = true;
            CheckOffline();
            levelChanger.FadeToLevel();
        }
    }

    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }

    public void CheckOffline()
    {
        TimeSpan timeSpan;
        if (PlayerPrefs.HasKey("LastSession"))
        {
            timeSpan = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString("LastSession"));
            print(string.Format("��� �� ����: {0} ����, {1} �����, {2} �����, {3} ������",
                timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds));

            if (/*timeSpan.Days >= 0 && timeSpan.Hours >= 4*/timeSpan.Seconds > 15)
            {
                SceneManager.LoadScene(5);
            }
            //if (timeSpan.Days == 0 && timeSpan.Hours < 4)
            //{
            //    SceneManager.LoadScene(1);
            //}
            //if (/*timeSpan.Days >= 0 && timeSpan.Hours >= 4*/timeSpan.Seconds < 15)
            //{
            //    levelChanger.FadeToLevel();
            //}
            
        }
        //PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
    }
}
