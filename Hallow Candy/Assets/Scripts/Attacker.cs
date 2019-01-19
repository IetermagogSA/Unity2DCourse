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


    public void Attack(GameObject defender)
    {
        currentDefender = defender;

        if(currentDefender)
        {
            currentDefender.GetComponent<Health>().ReduceHealth(damageDealt);
        }
    }
}
