using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField] AudioClip blockBreakClip;

    LevelScript levelscript;
    private void Start()
    {
        levelscript = FindObjectOfType<LevelScript>();
        levelscript.CountBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(blockBreakClip, Camera.main.transform.position);
        levelscript.DecreaseBlocks();
        Destroy(gameObject);
    }
}
