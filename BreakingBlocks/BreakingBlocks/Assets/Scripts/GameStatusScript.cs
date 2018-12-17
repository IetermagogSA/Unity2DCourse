using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatusScript : MonoBehaviour
{

	[Range(0.1f,20f)]
	[SerializeField] float myTimeScale;
	[SerializeField] int pointsPerBlock = 1;
	[SerializeField] int playerScore = 0;
	[SerializeField] TextMeshProUGUI playerScoreText;

	private void Awake()
	{
		int gameStatusCount = FindObjectsOfType<GameStatusScript>().Length;
		if(gameStatusCount > 1)
		{
            gameObject.SetActive(false);
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}

    private void Start()
    {
        playerScoreText.text = playerScore.ToString();
    }

    // Update is called once per frame
    void Update ()
	{
		Time.timeScale = myTimeScale;
	}

	public void increaseScore()
	{
		playerScore += pointsPerBlock;
        playerScoreText.text = playerScore.ToString();
    }
}
