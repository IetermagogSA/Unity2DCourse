using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] int damageDealt = 15;

    GameObject currentDefender;

    private void Update()
    {
        if(!currentDefender)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Defender")
        {
            currentDefender = collision.transform.parent.gameObject as GameObject;
            GetComponent<Animator>().SetBool("isAttacking", true);
            Attack();
        }
    }

    public void Attack()
    {
        if(currentDefender)
        {
            currentDefender.GetComponent<Health>().ReduceHealth(damageDealt);
        }
    }
}
