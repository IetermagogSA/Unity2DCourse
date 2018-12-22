using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    // Config Params
    WaveConfig waveConfig;

    // State variables
    List<GameObject> paths;
    List<Transform> pathWayPointList;
    int currentWayPointIndex = 0;

    private void Start()
    {
        GameObject path = waveConfig.GetPath();
        pathWayPointList = path.GetComponentsInChildren<Transform>().ToList();
        // Remove the parent object
        pathWayPointList.RemoveAt(0);

        transform.position = pathWayPointList[currentWayPointIndex].transform.position;
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (currentWayPointIndex <= pathWayPointList.Count - 1)
        {
            var targetPosition = pathWayPointList[currentWayPointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                currentWayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
