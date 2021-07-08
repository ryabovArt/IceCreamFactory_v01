using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    #region [Smiles]
    [SerializeField] private ParticleSystem[] smilesLeft;
    [SerializeField] private ParticleSystem[] smilesRight;

    [SerializeField] private Material[] materials;
    #endregion

    #region [Confetti]

    [SerializeField] private ParticleSystem[] confetti;
    //[SerializeField] private ParticleSystem fallConfetti;

    #endregion

    private void OnEnable()
    {
        EndLevel.endLevel += PlayConfetti;
    }

    private void OnDisable()
    {
        EndLevel.endLevel -= PlayConfetti;
    }

    #region [Smiles]

    /// <summary>
    /// Активируем веселые смайлики
    /// </summary>
    public void Smiles()
    {
        var setNewPosLeft = transform.GetChild(0);
        setNewPosLeft.position = new Vector3(Random.Range(2.3f, 1.9f), Random.Range(0.7f, 4f), 2f);
        var setNewPosRight = transform.GetChild(1);
        setNewPosRight.position = new Vector3(Random.Range(0.45f, 0.1f), Random.Range(0.7f, 4f), 2f);

        StartCoroutine(LeftParticleDelay());
        StartCoroutine(RightParticleDelay());
    }

    IEnumerator LeftParticleDelay()
    {
        for (int i = 0; i < 7; i++)
        {
            smilesLeft[Random.Range(0, smilesLeft.Length - 2)].Play();
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator RightParticleDelay()
    {
        for (int i = 0; i < 7; i++)
        {
            smilesRight[Random.Range(0, smilesRight.Length - 2)].Play();
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator LeftSadParticleDelay()
    {
        for (int i = 0; i < 4; i++)
        {
            smilesLeft[Random.Range(5, 7)].Play();
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator RightSadParticleDelay()
    {
        for (int i = 0; i < 4; i++)
        {
            smilesRight[Random.Range(5, 7)].Play();
            yield return new WaitForSeconds(0.2f);
        }
    }

    /// <summary>
    /// Активируем грустные смайлики смайлики
    /// </summary>
    public void SetSadSmile()
    {
        var setNewPos = transform.GetChild(0);
        setNewPos.position = new Vector3(Random.Range(2.3f, 1.9f), Random.Range(0.7f, 2.5f), 0.2f);
        var setNewPosRight = transform.GetChild(1);
        setNewPosRight.position = new Vector3(Random.Range(0.45f, 0), Random.Range(0.7f, 3f), 2f);

        StartCoroutine(LeftSadParticleDelay());
        StartCoroutine(RightSadParticleDelay());
    }
    #endregion

    #region [Confetti]

    /// <summary>
    /// Активируем конфетти
    /// </summary>
    public void PlayConfetti()
    {
        foreach (var particle in confetti)
        {
            particle.Play();
        }
    }

    //public void PlayFallConfetti()
    //{
    //    fallConfetti.Play();
    //}

    #endregion
}
