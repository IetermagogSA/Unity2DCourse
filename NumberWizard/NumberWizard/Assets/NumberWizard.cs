using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{

	int max = 1000, min = 1, guess = 500;

	// Use this for initialization
	void Start ()
	{
		StartGame();
	}

	void StartGame()
	{
		max = 1000, min = 1, guess = 500;
		Debug.Log("Howzit? Welcome to the number wizard!");
		Debug.Log("Pick a number");
		Debug.Log("The highest number you can pick is: " + max);
		Debug.Log("The lowest number you can pick is: " + min);
		Debug.Log("Tell me if your number is higher or lower than " + guess + "...");
		Debug.Log("UpArrow = Higher, DownArrow = Lower, Enter = Correct");
		max += 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Detect the key that has been pressed to determine if the number is higher, lower or correct
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			min = guess;
			NextGuess();
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			max = guess;
			NextGuess();
		}
		else if (Input.GetKeyDown(KeyCode.Return))
		{
			Debug.Log("The guess was correct! Yay!");
			StartGame();
		}
	}

	void NextGuess()
	{
		guess = (max + min) / 2;
		Debug.Log("Tell me if your number is higher or lower than " + guess + "...");
	}
}
