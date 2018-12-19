﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Config Params
    [SerializeField] float playerSpeed = 15f;
    [SerializeField] float padding = 1f;

    // Reference Variables
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    private void Start()
    {
        SetUpPlayerBoundaries();
    }

    private void SetUpPlayerBoundaries()
    {
        Camera mainCamera = Camera.main;
        xMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();        
    }

    private void MovePlayer()
    {
        // Move on the x-Axis
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        Debug.Log("DeltaX: " + deltaX + " xMin: " + xMin + " xMax: " + xMax);
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);        

        // Move on the y-Axis
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;
        var newYPos = Mathf.Clamp(transform.position.y + deltaY,yMin,yMax);

        // Translate the move to the player
        transform.position = new Vector2(newXPos, newYPos);
    }
}
