using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNuts : MonoBehaviour
{
    [SerializeField] private Transform target;

    public GameObject nut;

    public static bool isSpawnNuts;

    /// <summary>
    /// Спавним посыпку
    /// </summary>
    private void Update()
    {
        if (isSpawnNuts)
            Instantiate(nut, new Vector3(target.position.x + Random.Range(-0.4f, 0.4f), target.position.y, target.position.z + Random.Range(0, 0.4f)), Quaternion.identity);
    }
}
