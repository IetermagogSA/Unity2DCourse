using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Defender")
        {
            GetComponent<Attacker>().Attack(collision.transform.parent.gameObject as GameObject);
        }
    }
}
