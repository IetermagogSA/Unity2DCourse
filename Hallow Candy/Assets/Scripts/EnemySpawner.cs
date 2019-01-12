using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemiesToSpawn;
    [SerializeField] float minSpawnRate = 10f;
    [SerializeField] float maxSpawnRate = 20f;
    [SerializeField] float offSet = 0.25f;

    bool enableSpawn = true;

    IEnumerator Start()
    {
        while(enableSpawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnRate, maxSpawnRate));
            SpawnEnemy();
        }

    }

    private void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPosition = transform.position;
        spawnPosition.y -= offSet;

        Enemy newEnemy = Instantiate(enemiesToSpawn, spawnPosition, Quaternion.identity) as Enemy;
        newEnemy.transform.parent = transform;
    }

}
