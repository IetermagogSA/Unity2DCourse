using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlySpider : MonoBehaviour
{
    [SerializeField] float minSpeed = 0.8f;
    [SerializeField] float maxSpeed = 2.5f;
    [SerializeField] float minPauseDuration = 1f;
    [SerializeField] float maxPauseDuration = 2.5f;

    Vector3 spawnPos, randomDropPos;
    float movementSpeed = 0f;
    bool descendLocationReached = false, pauseObject = false;
    Animator animator;
    float randomPauseDuration;
    LineRenderer lineRenderer;

    private void Awake()
    {



    }

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWiggling", true);

        spawnPos = transform.position;
        randomDropPos = new Vector3(transform.position.x, UnityEngine.Random.Range(1f, 3f));
        movementSpeed = UnityEngine.Random.Range(minSpeed, maxSpeed);
        randomPauseDuration = UnityEngine.Random.Range(minPauseDuration, maxPauseDuration);

        lineRenderer = GetComponent<LineRenderer>();

    }

    void Update()
    {
        if (!pauseObject)
        {
            if (descendLocationReached)
            {
                Ascend();
            }
            else
            {
                Descend();
            }

            DrawLine();
        }
    }

    private void DrawLine()
    {
        lineRenderer.SetPosition(0, spawnPos);
        lineRenderer.SetPosition(1, transform.position);
    }

    private void Descend()
    {
        var movementThisFrame = movementSpeed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, randomDropPos, movementThisFrame);

        if(transform.position.y == randomDropPos.y)
        {
            StartCoroutine(PauseAndMoveToNextLocation());
            descendLocationReached = true;
        }
    }

    private void Ascend()
    {
        var movementThisFrame = movementSpeed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position , spawnPos, movementThisFrame);

        if (transform.position.y == spawnPos.y )
        {
            descendLocationReached = false;
            Destroy(gameObject);
        }

    }

    IEnumerator PauseAndMoveToNextLocation()
    {
        pauseObject = true;

        yield return new WaitForSeconds(randomPauseDuration);

        pauseObject = false;
    }
}
