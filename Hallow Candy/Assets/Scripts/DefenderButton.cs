using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defender;

    SpriteRenderer sprite;

    private void OnMouseDown()
    {
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defender);
    }
    private void OnMouseOver()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.white;
    }

    private void OnMouseExit()
    {
        sprite.color = Color.grey;
    }
}
