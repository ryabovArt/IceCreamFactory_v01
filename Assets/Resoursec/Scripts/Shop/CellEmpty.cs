using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellEmpty : MonoBehaviour
{
    public GameObject Main, Unknown;

    bool check = true;

    public void ExampleFunc()
    {
        if (check)
        {
            Main.SetActive(true);
            Unknown.SetActive(false);
            check = false;
        }
        else
        {
            Main.SetActive(false);
            Unknown.SetActive(true);
            check = true;
        }
    }
}
