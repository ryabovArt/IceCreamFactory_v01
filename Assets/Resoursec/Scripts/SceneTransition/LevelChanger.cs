using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int levelToLoad;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            animator.SetTrigger("fadeOut");
        }
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("fade");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void HideFadePanel()
    {
        gameObject.SetActive(false);
    }
}
