using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    public void SetSelectedDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }
    private void OnMouseDown()
    {
        //Debug.Log("The mouse button has been clicked!");
        SpawnDefender(GetSquareClicked());
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        worldPos.x = Mathf.RoundToInt(worldPos.x);
        worldPos.y = Mathf.RoundToInt(worldPos.y) - 0.25f; // 0.25f is a small offset so that it looks good

        return worldPos;
    }

    private void SpawnDefender(Vector2 spawnPoint)
    {
        Instantiate(defender, spawnPoint, transform.rotation);
    }
}
