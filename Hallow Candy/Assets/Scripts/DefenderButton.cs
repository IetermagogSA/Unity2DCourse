using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    SpriteRenderer sprite;
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
