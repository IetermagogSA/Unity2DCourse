using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemiesToSpawn;
    [SerializeField] float minSpawnRate = 10f;
    [SerializeField] float maxSpawnRate = 20f;

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
        GameObject.Instantiate(enemiesToSpawn, transform.position, Quaternion.identity);
    }

}
