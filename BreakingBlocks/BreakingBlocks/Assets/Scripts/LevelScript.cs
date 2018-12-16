using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public int numberOfBlocks = 0;
    public SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        numberOfBlocks++;
    }    

    public void DecreaseBlocks()
    {
        numberOfBlocks--;

        // Load the next level
        if(numberOfBlocks == 0)
        {
            sceneloader.LoadNextScene();
        }
    }
}
