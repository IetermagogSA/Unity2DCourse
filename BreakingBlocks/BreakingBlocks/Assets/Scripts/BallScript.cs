using UnityEngine;

public class BallScript : MonoBehaviour
{
	// Param Settings
	[SerializeField] PaddleScript paddle1;
	[SerializeField] float pushX = 2f;
	[SerializeField] float pushY = 15f;
	[SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

	// State variables
	Vector2 paddleToBallVector;
	bool hasStarted = false;

	// Reference variables
	AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;

	// Use this for initialization
	void Start ()
	{
		paddleToBallVector = transform.position - paddle1.transform.position;
		myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!hasStarted)
		{
			AttachToPaddle();
			Launch();
		}		
	}

	private void Launch()
	{
		if(Input.GetMouseButtonDown(0))
		{
			myRigidbody2D.velocity = new Vector2(pushX,pushY);
			hasStarted = true;
		}
	}

	private void AttachToPaddle()
	{
		Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
		transform.position = paddlePos + paddleToBallVector;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            myAudioSource.clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(myAudioSource.clip);

            myRigidbody2D.velocity += velocityTweak;
        }
	}
}
