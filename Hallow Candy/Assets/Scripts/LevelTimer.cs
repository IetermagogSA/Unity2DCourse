using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    [Tooltip("The total time of the level in SECONDS")]
    [SerializeField] float levelTimeInSeconds = 60;
    void Update()
    {
        GetComponent<Slider>().value = (Time.timeSinceLevelLoad / levelTimeInSeconds) * 100;

        bool levelTimerFinished = (Time.timeSinceLevelLoad > levelTimeInSeconds);

        if(levelTimerFinished)
        {
            FindObjectOfType<LevelController>().SetLevelTimerFinished();
        }
    }
}
