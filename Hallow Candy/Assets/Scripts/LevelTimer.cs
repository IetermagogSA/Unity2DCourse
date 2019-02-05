using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    [Tooltip("The total time of the level in SECONDS")]
    [SerializeField] float levelTimeInSeconds = 60;

    private bool hasSetSpawnRate = false;

    Slider levelTimerSlider;
    private void Start()
    {
        levelTimerSlider = GetComponent<Slider>();
    }
    void Update()
    {
        levelTimerSlider.value = (Time.timeSinceLevelLoad / levelTimeInSeconds) * 100;

        if (levelTimerSlider.value == 30f || levelTimerSlider.value == 60f)
        {
            if (!hasSetSpawnRate)
            {
                IncreaseSpawnRate();
            }
        }
        else
        {
            hasSetSpawnRate = false;
        }

        bool levelTimerFinished = (Time.timeSinceLevelLoad > levelTimeInSeconds);

        if(levelTimerFinished)
        {
            FindObjectOfType<LevelController>().SetLevelTimerFinished();
        }
    }

    private void IncreaseSpawnRate()
    {
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();
        foreach(EnemySpawner spawner in spawners)
        {
            spawner.minSpawnRate /= 1.5f;
            spawner.maxSpawnRate /= 1.5f;
        }

        hasSetSpawnRate = true;        
    }
}
