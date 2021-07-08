using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    private static SceneTransition instance;
    private static bool isShouldPlayOpeningAnimation = false;

    private Animator sceneTransitionAnimator;

    private AsyncOperation loadingSceneOperation;

    [SerializeField] private GameObject fadePanel;

    /// <summary>
    /// Смена сцены
    /// </summary>
    /// <param name="sceneName">имя сцены</param>
    public static void SwichToScene(string sceneName)
    {
        instance.sceneTransitionAnimator.SetTrigger("startScene");

        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        instance.loadingSceneOperation.allowSceneActivation = false;
    }

    void Start()
    {
        instance = this;

        sceneTransitionAnimator = GetComponent<Animator>();

        if (isShouldPlayOpeningAnimation) sceneTransitionAnimator.SetTrigger("endScene");

    }

    /// <summary>
    /// Действия при окончании анимации затухания панели при смене сцены
    /// </summary>
    public void OnAnimationOver()
    {
        isShouldPlayOpeningAnimation = true;
        loadingSceneOperation.allowSceneActivation = true;
    }

    /// <summary>
    /// Сокрытие панели при смене сцены
    /// </summary>
    public void HideFadePanel()
    {
        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            fadePanel.SetActive(false);
        }
    }
}
