﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float gameOverDelayTime = 1f;
    public void LoadGameOver()
    {
        StartCoroutine(LoadGameOverAfterDelay());
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
        FindObjectOfType<GameSession>().ResetScore();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadGameOverAfterDelay()
    {
        yield return new WaitForSeconds(gameOverDelayTime);
        SceneManager.LoadScene("GameOver");
    }
}
