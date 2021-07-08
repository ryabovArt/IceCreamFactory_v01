using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTransporter : MonoBehaviour
{
    [SerializeField] private Transporter transporter;

    private Transform endPoint;
    [SerializeField] private GameObject chunks;
    [SerializeField] private GameObject firstChunk;

    [SerializeField] private List<GameObject> spawnedChunks;

    void Start()
    {
        endPoint = GameManager.instance.DestroyPoint;
        //spawnedChunks.Add(firstChunk);
        //StartCoroutine(SpawnChunk());
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedChunks[spawnedChunks.Count - 1].transform.position.x > 9f)
        {
            GameObject newChunk = Instantiate(chunks);
            newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].GetComponent<Transporter>().End.position - newChunk.GetComponent<Transporter>().Begin.localPosition;
            spawnedChunks.Add(newChunk);
        }
        if (spawnedChunks.Count == 2)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }

    //IEnumerator SpawnChunk()
    //{
    //    if (spawnedChunks[spawnedChunks.Count - 1].transform.position.x < 0)
    //    {
    //        GameObject newChunk = Instantiate(chunks);
    //        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
    //        spawnedChunks.Add(newChunk);
    //    }
    //    yield return new WaitForSeconds(3f);
    //    StartCoroutine(SpawnChunk());
    //}
}
