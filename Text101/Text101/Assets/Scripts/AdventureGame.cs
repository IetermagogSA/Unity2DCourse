using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour {

	[SerializeField] TextMeshProUGUI storyText;
	[SerializeField] State startingState;

	State currentState;
	// Use this for initialization
	void Start ()
	{
		currentState = startingState;
		storyText.text = "Story time!";

		storyText.text = currentState.GetStateStory();


	}
	
	// Update is called once per frame
	void Update ()
	{
		ManageStates();	
	}

	private void ManageStates()
	{
		var nextState = currentState.GetNextStates();

		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			currentState = nextState[0];
		}
		else if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			currentState = nextState[1];
		}
		else if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			currentState = nextState[2];
		}

		storyText.text = currentState.GetStateStory();
	}
}
