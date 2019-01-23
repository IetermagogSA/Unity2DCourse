using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject levelCompleteCanvas;
    [SerializeField] GameObject gameOverCanvas;

    public bool isLevelTimerFinished = false;
    public int enemyCount = 0;


    private void Start()
    {
        Time.timeScale = 1;
        levelCompleteCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
    }

    void Update()
    {
        if(isLevelTimerFinished)
        {
            // Stop the spawners
            StopAllSpawners();
            LoadNextLevel();
        }
    }

    public void SetLevelTimerFinished()
    {
        isLevelTimerFinished = true;
    }

    private void StopAllSpawners()
    {
        EnemySpawner[] enemySpawners = FindObjectsOfType<EnemySpawner>();
        foreach(EnemySpawner enemySpawner in enemySpawners)
        {
            enemySpawner.stopSpawning = true;
            enemySpawner.StopCoroutine("Start");
        }
    }


    private void LoadNextLevel()
    {
        if (enemyCount <= 0)
        {
            // Stop the level
            Time.timeScale = 0;
            levelCompleteCanvas.SetActive(true);
        }
    }

    public void IncreaseEnemyCount()
    {
        enemyCount++;
    }

    public void DecreaseEnemyCount()
    {
        enemyCount--;
    }

    public void HandleGameOver()
    {
        gameOverCanvas.SetActive(true);
        FindObjectOfType<ClickManager>().enabled = false;
        // Pause the game
        Time.timeScale = 0;
    }

}
