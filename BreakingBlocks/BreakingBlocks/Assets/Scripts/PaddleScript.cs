using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{

	[SerializeField] float minX = 0f;
	[SerializeField] float maxX = 14f;
	[SerializeField] float screenWidthInUnits = 16f;

	// Update is called once per frame
	void Update ()
	{
		//Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);
		float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
		Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);

		paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);

		transform.position = paddlePos;
	}
}
