using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] float offSet = 0.25f;

    Defender defender;
    CandiesDisplay candiesDisplay;

    private void Start()
    {
        candiesDisplay = FindObjectOfType<CandiesDisplay>();
    }

    public void SetSelectedDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        worldPos.x = Mathf.RoundToInt(worldPos.x);
        worldPos.y = Mathf.RoundToInt(worldPos.y) - offSet; // 0.25f is a small offset so that it looks good

        return worldPos;
    }

    public void SpawnDefender()
    {
        if (defender)
        {
            candiesDisplay.DeceaseCandies(defender.GetDefenderCost());
            Instantiate(defender, GetSquareClicked(), transform.rotation);
            defender = null;
        }
    }
}
