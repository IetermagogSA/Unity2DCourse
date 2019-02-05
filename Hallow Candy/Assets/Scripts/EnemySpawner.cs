﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy[] enemiesToSpawn;
    [SerializeField] public float minSpawnRate = 1f;
    [SerializeField] public float maxSpawnRate = 1f;
    [SerializeField] float offSet = 0.25f;

    public bool stopSpawning = false;

    IEnumerator Start()
    {
        while(!stopSpawning)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnRate, maxSpawnRate));
            SpawnEnemy();
        }

    }

    private void SpawnEnemy()
    {
        int enemySpawnIndex = Random.Range(0, enemiesToSpawn.Length);
        Spawn(enemiesToSpawn[enemySpawnIndex]);
        FindObjectOfType<LevelController>().IncreaseEnemyCount();
    }

    private void Spawn(Enemy enemyToSpawn)
    {
        Vector3 spawnPosition = transform.position;
        spawnPosition.y -= offSet;
        spawnPosition.z = -1;

        Enemy newEnemy = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity) as Enemy;
        newEnemy.transform.parent = transform;
    }
}
