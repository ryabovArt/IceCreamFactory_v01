using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    private float filling = 0.9f;
    [SerializeField] private Renderer rend;

    /// <summary>
    /// Активируем шейдер заливки
    /// </summary>
    /// <param name="other"></param>
    private void OnParticleCollision(GameObject other)
    {
        StartCoroutine(StartFill());
        print("ParticleCollision");
    }

    IEnumerator StartFill()
    {
        if (transform.parent.position == GameManager.instance.firstIceCreamInDispenser.transform.position)
        {
            while (filling >= 0.3f)
            {
                filling -= 0.001f;
                rend.material.SetFloat("_transitionLevel", filling);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
