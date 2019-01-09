using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float attackSpeed = 0.5f;
    

    Animator animator;
    Gun gun;
    bool shooting = true;

    private void Start()
    {
        gun = GetComponentInChildren<Gun>();
        animator = GetComponent<Animator>();

        Fire(attackSpeed);
    }
    public void Fire(float speed)
    {
        StartCoroutine(FireProjectile());
    }

    IEnumerator FireProjectile()
    {
        while (shooting)
        {
            yield return new WaitForSeconds(attackSpeed);
            var proj = Instantiate(projectile, gun.transform.position, new Quaternion(0f, 0f, -90f, 90f));
            animator.Play("Shooting");
        }
    }
}
