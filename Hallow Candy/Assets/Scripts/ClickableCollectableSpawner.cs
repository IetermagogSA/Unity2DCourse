using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableCollectableSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] clickableCollectables;
    [SerializeField] float minSpawnDelay = 10f;
    [SerializeField] float maxSpawnDelay = 25f;

    [SerializeField] float minXSpawnLocation = 1f;
    [SerializeField] float maxXSpawnLocation = 10f;
    [SerializeField] float minYSpawnLocation = 1f;
    [SerializeField] float maxYSpawnLocation = 5f;

    float randomSpawnTime = 0f;
    float elapsedTime = 0f;
    Vector3 spawnPos;

    private void Start()
    {
        randomSpawnTime = Random.Range(minSpawnDelay, maxSpawnDelay);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= randomSpawnTime)
        {
            SpawnClickableCollectable();
        }
    }

    private void SpawnClickableCollectable()
    {
        spawnPos = new Vector3(Random.Range(minXSpawnLocation, maxXSpawnLocation), Random.Range(minYSpawnLocation, maxYSpawnLocation), 0f);
        //spawnPos = Camera.main.ScreenToWorldPoint(spawnPos);

        Instantiate(clickableCollectables[Random.Range(0, clickableCollectables.Length)], spawnPos, Quaternion.identity);
        elapsedTime = 0;
        randomSpawnTime = Random.Range(minSpawnDelay, maxSpawnDelay);
    }
}
