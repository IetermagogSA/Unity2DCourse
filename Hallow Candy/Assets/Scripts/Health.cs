using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 20;

    Animator animator;
    PolygonCollider2D collider;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<PolygonCollider2D>();
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
        collider.enabled = false;
        //animator.Play("Dying");
        animator.SetBool("isDying", true);
        yield return new WaitForEndOfFrame(); // We need to wait for the next frame before the correct length of the clip will be returned

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);        
    }
}
