using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] int enemyHealth = 100;

    [Header("Projectile")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject enemyProjectile;
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] GameObject explosionVFX;

    [Header("Audio")]
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip fireSound;
    [SerializeField] [Range(0f, 1f)] float fireSoundVolume = 0.01f;
    [SerializeField] [Range(0f, 1f)] float deathSoundVolume = 0.1f;

    private void Start()
    {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Update()
    {
        CountDownAndShoot();        
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0f)
        {
            Fire();
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject projectile = Instantiate(enemyProjectile, transform.position, new Quaternion(180f, 0f, 0f, 0f)) as GameObject;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -(projectileSpeed));
        AudioSource.PlayClipAtPoint(fireSound, Camera.main.transform.position, fireSoundVolume);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        HandleHit(damageDealer);
    }

    private void HandleHit(DamageDealer damageDealer)
    {
        enemyHealth -= damageDealer.GetDamage();
        damageDealer.Hit();

        if (enemyHealth <= 0)
        {
            StartCoroutine(PlayVFX());
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }

    IEnumerator PlayVFX()
    {
        GameObject explosion = Instantiate(explosionVFX, transform.position, Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(1f);
        Destroy(explosion);
    }
}
