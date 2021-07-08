using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedIceCream : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (SceneManager.GetActiveScene().name == "Win")
        {
            gameObject.SetActive(true);
        }
    }
}
