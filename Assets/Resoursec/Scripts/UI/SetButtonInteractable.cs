using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetButtonInteractable : MonoBehaviour
{
    private Button btn;
    
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(CheckClic);
    }

    /// <summary>
    /// Спавним мороженое через время
    /// </summary>
    private void CheckClic()
    {
        StartCoroutine(InteractableButton());
    }

    IEnumerator InteractableButton()
    {
        btn.interactable = false;
        yield return new WaitForSeconds(0.8f);
        btn.interactable = true;
    }
}
