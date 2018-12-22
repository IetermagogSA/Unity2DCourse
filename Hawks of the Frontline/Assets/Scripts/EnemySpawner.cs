using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAllWaves());
    }

    IEnumerator SpawnAllEnemiesInWave(WaveConfig currentWaveConfig)
    {
        currentWaveConfig.GenerateRandomgPath();

        for (int enemyCounter = 1; enemyCounter <= currentWaveConfig.GetNumberOfEnemies(); enemyCounter++)
        {
            var newEnemy = Instantiate(currentWaveConfig.GetEnemyPrefab(), currentWaveConfig.GetPath().transform.position, new Quaternion(180f,0f,0f,0f));
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(currentWaveConfig);
            yield return new WaitForSeconds(currentWaveConfig.GetTimeBetweenSpawns());
        }
    }

    IEnumerator SpawnAllWaves()
    {
        foreach(WaveConfig waveConfig in waveConfigs)
        {
            yield return StartCoroutine(SpawnAllEnemiesInWave(waveConfig));
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
