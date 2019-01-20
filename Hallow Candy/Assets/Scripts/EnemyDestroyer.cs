using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            transform.Find("Game Over Canvas").GetComponent<Canvas>().enabled = true;
            // Pause the game
            Time.timeScale = 0;
        }
    }
}
