using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(0f,10f)]
    [SerializeField] float speed = 0.25f;

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }

    public void SetMovementSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelController>().DecreaseEnemyCount();
    }
}
