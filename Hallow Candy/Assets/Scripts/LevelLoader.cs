using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 4;
    int currentSceneIndex;

    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadMainMenu());
    }

    IEnumerator LoadMainMenu()
    {
        if (currentSceneIndex == 0)
        {
            yield return new WaitForSeconds(timeToWait);
            LoadNextScene();
        }
    }

    public void LoadMainMenuNoWait()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadLevelMap()
    {
        SceneManager.LoadScene("Level Map");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
