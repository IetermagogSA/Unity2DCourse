using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BatCollectable : MonoBehaviour
{

    [SerializeField] GameObject[] paths;
    [SerializeField] float minSpeed = 1.5f;
    [SerializeField] float maxSpeed = 4f;
    [SerializeField] float minPauseDuration = 0.2f;
    [SerializeField] float maxPauseDuration = 1f;

    GameObject pathToFollow;

    List<Transform> pathWayPointList;
    int currentWayPointIndex = 0;
    Vector3 targetPosition;
    float scaleFactor = 0f;
    bool pauseObject = false;
    float speed = 0f;
    int maxHits = 0;

    private void Start()
    {
        GetNewRandomSpeed();

        SetupFlyingPath();

        scaleFactor = transform.localScale.x;

        SetRotation();
    }

    private void SetupFlyingPath()
    {
        pathToFollow = paths[Random.Range(0, paths.Length)];

        pathWayPointList = pathToFollow.GetComponentsInChildren<Transform>().ToList();
        // Remove the parent path
        pathWayPointList.RemoveAt(0);

        transform.position = pathWayPointList[currentWayPointIndex].transform.position;
    }

    private void Update()
    {
        if (!pauseObject)
        {
            Move();
        }
    }

    private void GetNewRandomSpeed()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void Move()
    {
        if(currentWayPointIndex <= pathWayPointList.Count - 1)
        {
            targetPosition = pathWayPointList[currentWayPointIndex].transform.position;
            var movementThisFrame = speed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if(transform.position == targetPosition)
            {
                StartCoroutine(PauseAndMoveToNextLocation());
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void SetRotation()
    {
        if (currentWayPointIndex + 1 < pathWayPointList.Count)
        {
            targetPosition = pathWayPointList[currentWayPointIndex + 1].transform.position;
        }

        float rotationFactor = 0f;

        if (transform.position.x >= targetPosition.x)
        {
            rotationFactor = scaleFactor;
        }
        else
        {
            rotationFactor = -(scaleFactor);
        }

        Vector3 newScale = new Vector3(rotationFactor, transform.localScale.y, transform.localScale.z);
        transform.localScale = newScale;
    }

    IEnumerator PauseAndMoveToNextLocation()
    {
        pauseObject = true;

        yield return new WaitForSeconds(Random.Range(minPauseDuration, maxPauseDuration));

        SetRotation();
        currentWayPointIndex++;
        pauseObject = false;
        GetNewRandomSpeed();
    }
}
