using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInto : MonoBehaviour
{
    Animator anim;
    LevelController levelController;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        levelController = FindObjectOfType<LevelController>();
    }

    public void Pause()
    {
        levelController.PauseGame(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && levelController.hasGameStarted == false)
        {
            anim.SetTrigger("isReadyTrigger");
            levelController.ResumeGame();
            levelController.hasGameStarted = true;
        }
    }
}
