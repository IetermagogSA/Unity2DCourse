using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy[] enemiesToSpawn;
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

    private void SpawnEnemy()
    {
        int enemySpawnIndex = Random.Range(0, enemiesToSpawn.Length);
        Spawn(enemiesToSpawn[enemySpawnIndex]);
    }

    private void Spawn(Enemy enemyToSpawn)
    {
        Vector2 spawnPosition = transform.position;
        spawnPosition.y -= offSet;

        Enemy newEnemy = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity) as Enemy;
        newEnemy.transform.parent = transform;
    }

}
