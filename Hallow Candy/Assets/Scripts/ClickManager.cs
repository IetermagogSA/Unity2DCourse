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

            int layerMask = 1 << 12;
            // Does the ray intersect any objects which are in the ClickableCollectable layer.
            if (Physics2D.Raycast(mousePos2D, Vector3.forward, Mathf.Infinity, layerMask))
            {
                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, layerMask);
                hit.collider.GetComponent<CollectableHitController>().HandleHit();
            }
            else
            { 
                layerMask = 1 << 9;
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
                        // Destroy the defender if the scytche has been selected
                        Defender defender = FindObjectOfType<DefenderSpawner>().GetSelectedDefender();
                        if (defender)
                        {
                            if (defender.GetDefenderCost() == 0)
                            {
                                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, layerMask);

                                if (hit.collider.tag == "Defender")
                                {
                                    GameObject.Destroy(hit.collider.gameObject);
                                    // Destroy the parent as well - this is the actual gameobject we want
                                    hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, layerMask);
                                    GameObject.Destroy(hit.collider.gameObject);
                                }
                                else
                                {
                                    GameObject.Destroy(hit.collider.gameObject);
                                }

                                FindObjectOfType<DefenderSpawner>().ResetSelectedDefender();
                                FindObjectOfType<DefenderButton>().DeselectDefenderButtons();
                            }
                        }
                    }
                    else  // Does the ray intersect any objects which are in the GameArea layer.
                    {
                        layerMask = 1 << 8;
                        if (Physics2D.Raycast(mousePos2D, Vector3.forward, Mathf.Infinity, layerMask))
                        {
                            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, layerMask);
                            if (FindObjectOfType<DefenderSpawner>().GetSelectedDefender())
                            {
                                FindObjectOfType<DefenderSpawner>().SpawnDefender();
                            }
                        }
                    }
                }
            }
        }
    }
}
