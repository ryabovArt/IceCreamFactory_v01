using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeDistanceToCamera : MonoBehaviour
{
    /// <summary>
    /// —тавим рожок в указанное место, в зависимости, сколько на нем шариков мороженого
    /// </summary>
    void Start()
    {
        if (GameManager.staticLevel == 0 || GameManager.staticLevel == 1)
        {
            transform.position = new Vector3(0.15f, 1.38f, 0.79f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (GameManager.staticLevel == 2)
        {
            transform.position = new Vector3(-0.05f, 1f, 0.39f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (GameManager.staticLevel == 3)
        {
            transform.position = new Vector3(0, 1f, 0.63f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (GameManager.staticLevel == 4)
        {
            transform.position = new Vector3(0.12f, 0.55f, 0.76f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
