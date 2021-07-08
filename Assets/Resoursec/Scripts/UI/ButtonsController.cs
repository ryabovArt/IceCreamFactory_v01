using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject sceneTransition;
    [SerializeField] private GameObject spawnIceCreamButton;

    [SerializeField] private Animator optionsPanelAnimator;

    public void GoToGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    /// <summary>
    /// Показываем опции
    /// </summary>
    public void ShowOptions()
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
        optionsPanelAnimator.SetTrigger("ShowOptions");
    }

    /// <summary>
    /// Скрываем опции
    /// </summary>
    public void HideOptions()
    {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
    }

    public void DestroySceneTransition()
    {
        sceneTransition.SetActive(false);
    }

    public void GoToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void DestroyGameObject()
    {
        Destroy(GameObject.FindGameObjectWithTag("WaffleCone"));
    }

    public void ResetToZeroMoveDispenserIndex()
    {
        MoveDispenser.index = 0;
    }

    public void GoToDailyBonus()
    {
        SceneManager.LoadScene(5);
    }
}
