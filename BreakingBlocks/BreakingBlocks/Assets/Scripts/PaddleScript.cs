using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{

	[SerializeField] float minX = 0f;
	[SerializeField] float maxX = 14f;
	[SerializeField] float screenWidthInUnits = 16f;

    // Reference variables
    GameStatusScript gameScript;
    BallScript ballScript;

    private void Start()
    {
        gameScript = FindObjectOfType<GameStatusScript>();
        ballScript = FindObjectOfType<BallScript>();
    }

    // Update is called once per frame
    void Update ()
	{
		//float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
		Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);

		paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);

		transform.position = paddlePos;
	}

    private float GetXPos()
    {
        if(gameScript.isActiveAndEnabled)
        {
            return ballScript.transform.position.x;
        }
        else
        {
           return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }

    }
}
