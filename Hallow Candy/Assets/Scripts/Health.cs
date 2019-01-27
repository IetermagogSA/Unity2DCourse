﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 20;

    Animator animator;
    PolygonCollider2D collider;

    private void Awake()
    {
        // Set the health based on the difficulty -- only if this is set on an enemy
        if (FindObjectOfType<Enemy>())
        {
            switch (PlayerPrefsController.GetDifficulty())
            {
                case 0:
                    // do nothing
                    break;
                case 1:
                    health *= 2;
                    break;
                case 2:
                    health *= 3;
                    break;
            }
        }


        animator = GetComponent<Animator>();

        if (GetComponent<PolygonCollider2D>())
        {
            collider = GetComponent<PolygonCollider2D>();
        }
    }
    public int GetHealth()
    {
        return health;
    }

    public void ReduceHealth(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        if (collider)
        {
            collider.enabled = false;
        }

        //animator.Play("Dying");
        animator.SetBool("isDying", true);
        yield return new WaitForEndOfFrame(); // We need to wait for the next frame before the correct length of the clip will be returned

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);        
    }
}
