using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            int layerMask = 1 << 9;
            // Does the ray intersect any objects which are in the CurrencyCandy layer.
            if (Physics2D.Raycast(mousePos2D, Vector3.forward, Mathf.Infinity, layerMask))
            {
                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, layerMask);
                hit.collider.GetComponent<CurrencyCandy>().CandyClicked();
            }
            else
            {
                layerMask = 1 << 10;
                // Does the ray intersect any objects which are in the Defender layer.
                if (Physics2D.Raycast(mousePos2D, Vector3.forward, Mathf.Infinity, layerMask))
                {
                    // Do not allow spawning
                }
                else  // Does the ray intersect any objects which are in the GameArea layer.
                {
                    layerMask = 1 << 8;
                    if (Physics2D.Raycast(mousePos2D, Vector3.forward, Mathf.Infinity, layerMask))
                    {
                        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, layerMask);
                        FindObjectOfType<DefenderSpawner>().SpawnDefender();
                    }
                }
            }
        }
    }
}
