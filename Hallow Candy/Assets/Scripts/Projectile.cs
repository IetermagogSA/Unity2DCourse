using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 2f;
    [SerializeField] int projectileDamage = 1;
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0f);
    }

    private void Update()
    {
        //transform.Translate(-transform.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Health>().ReduceHealth(projectileDamage);
            Debug.Log("Collision Detected");
            Destroy(gameObject);
        }
    }
}
