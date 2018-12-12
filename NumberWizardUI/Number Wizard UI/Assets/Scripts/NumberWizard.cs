using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
	[SerializeField]
	int min = 1;

	[SerializeField]
	int max = 1000;

	[SerializeField]
	TextMeshProUGUI guessText;

	int guess = 500;

	// Use this for initialization
	void Start ()
	{
		StartGame();
	}

	void StartGame()
	{
        NextGuess();
	}
	
	public void OnPressHigher()
	{
		min = guess + 1;
		NextGuess();
	}

	public void OnPressLower()
	{
		max = guess - 1;
		NextGuess();
	}

	void NextGuess()
	{
        guess = Random.Range(min, max + 1);
		guessText.text = guess.ToString();
    }
}
