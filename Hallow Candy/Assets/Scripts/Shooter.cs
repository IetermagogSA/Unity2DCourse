﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float attackSpeedCooldown= 4f;

    Animator animator;
    Gun gun;
    EnemySpawner myEnemySpawner;

    bool isAttackOnCooldown = false;

    private void Start()
    {
        gun = GetComponentInChildren<Gun>();
        animator = GetComponent<Animator>();

        GetMyEnemySpawner();
    }

    private void Update()
    {

        if(!isAttackOnCooldown)
        {
            if (isAttackerInLane())
            {
                StartCoroutine(Fire());
            }
            else
            {
                // Sit and wait
                animator.SetBool("isAttacking", false);
            }
        }

    }

    private void GetMyEnemySpawner()
    {
        EnemySpawner[] enemySpawners = FindObjectsOfType<EnemySpawner>();
        foreach(EnemySpawner enemySpawner in enemySpawners)
        {
            bool isCloseEnough = Mathf.Abs(enemySpawner.transform.position.y - (transform.position.y + 0.25f)) < Mathf.Epsilon;
            if(isCloseEnough)
            {
                myEnemySpawner = enemySpawner;
                break;
            }
        }
    }

    private bool isAttackerInLane()
    {
        if(myEnemySpawner.transform.childCount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator Fire()
    {
        isAttackOnCooldown = true;

        yield return new WaitForSeconds(attackSpeedCooldown);

        // Shoot
        animator.SetBool("isAttacking", true);

    }

    IEnumerator FireProjectile()
    {
        var proj = Instantiate(projectile, gun.transform.position, new Quaternion(0f, 0f, 0f, 90f));

        proj.transform.parent = gun.transform;

        yield return new WaitForEndOfFrame(); // We need to wait for the next frame before the correct length of the clip will be returned

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        animator.SetBool("isAttacking", false);

        isAttackOnCooldown = false;
    }
}
