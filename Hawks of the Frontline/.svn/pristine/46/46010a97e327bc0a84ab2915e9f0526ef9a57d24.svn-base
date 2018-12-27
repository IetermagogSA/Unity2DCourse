using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] List<GameObject> pathsPrefabs;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;


    int randomPathNumber = 0;

    public void GenerateRandomgPath()
    {
        randomPathNumber = Random.Range(0,pathsPrefabs.Count);
    }

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public GameObject GetPath()
    {
        return GetPathsPrefabs()[randomPathNumber];
    }

    public List<GameObject> GetPathsPrefabs()
    {
        return pathsPrefabs;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
