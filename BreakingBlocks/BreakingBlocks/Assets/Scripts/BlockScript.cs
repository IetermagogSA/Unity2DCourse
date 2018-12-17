using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField] AudioClip blockBreakClip;

    LevelScript levelscript;
    GameStatusScript gameStatusScript;
    private void Start()
    {
        levelscript = FindObjectOfType<LevelScript>();
        levelscript.CountBlocks();
        gameStatusScript = FindObjectOfType<GameStatusScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(blockBreakClip, Camera.main.transform.position);
        Destroy(gameObject);
        levelscript.DecreaseBlocks();
        gameStatusScript.increaseScore();
    }
}
