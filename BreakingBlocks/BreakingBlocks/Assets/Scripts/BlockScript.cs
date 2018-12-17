using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField] AudioClip blockBreakClip;
    [SerializeField] GameObject blockBreakSparkle;

    LevelScript levelscript;
    GameStatusScript gameStatusScript;
    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        levelscript = FindObjectOfType<LevelScript>();
        if (tag == "Breakable")
        {
            levelscript.CountBlocks();
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        PlayAudioAndVFX();
        Destroy(gameObject);
        levelscript.DecreaseBlocks();
        CalculateScore();
    }

    private void PlayAudioAndVFX()
    {
        AudioSource.PlayClipAtPoint(blockBreakClip, Camera.main.transform.position);
        GameObject sparkle = Instantiate(blockBreakSparkle, transform.position, transform.rotation);
        Destroy(sparkle, 2f);
    }

    private void CalculateScore()
    {
        gameStatusScript = FindObjectOfType<GameStatusScript>();
        gameStatusScript.increaseScore();
    }
}
