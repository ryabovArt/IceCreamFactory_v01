using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private int loadScene;

    [SerializeField] private GameObject loadindScreen;

    public void Load(int level)
    {
        loadindScreen.SetActive(true);
        SceneManager.LoadScene(level);
    }
}
