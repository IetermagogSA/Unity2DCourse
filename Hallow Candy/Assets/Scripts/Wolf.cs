using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Defender")
        {
            if (collision.transform.parent.gameObject.GetComponent<Blocker>())
            {
                GetComponent<Animator>().SetTrigger("jumpTrigger");
            }
            else
            {
                GetComponent<Attacker>().Attack(collision.transform.parent.gameObject as GameObject);
            }
        }
    }
}
