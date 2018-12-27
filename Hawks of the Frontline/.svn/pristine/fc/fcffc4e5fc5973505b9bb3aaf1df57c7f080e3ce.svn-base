using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    GameSession gameSession;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
    }

    private void Update()
    {
        Debug.Log(gameSession.GetScore().ToString());
        scoreText.text = gameSession.GetScore().ToString();
    }
}
