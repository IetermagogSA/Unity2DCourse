using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int playerScore;
    int playerHealth = 200;
    private void Awake()
    {
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void IncreaseScore(int points)
    {
        playerScore += points;
    }

    public void ResetScore()
    {
        Destroy(gameObject);
    }
}
