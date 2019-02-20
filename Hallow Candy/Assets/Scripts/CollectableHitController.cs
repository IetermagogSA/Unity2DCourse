using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableHitController : MonoBehaviour
{
    [SerializeField] GameObject[] collectables;
    [SerializeField] int hitsBetweenItemDrops = 10;

    CameraShake cameraShaker;
    int maxHits = 0;
    int currentHits = 0;
    int totalHitsTaken = 0;

    // Start is called before the first frame update
    void Start()
    {
        maxHits = hitsBetweenItemDrops * collectables.Length;
        cameraShaker = GetComponent<CameraShake>();
    }

    //private void Update()
    //{
    //    if(Input.GetMouseButtonDown(0))
    //    {
    //        HandleHit();
    //    }
    //}

    public void HandleHit()
    {
        // Play the hit animation
        GetComponent<Animator>().SetTrigger("hitTrigger");

        // Shake the camera if we have a CameraShaker
        if(cameraShaker)
        {
            cameraShaker.ShakeTheCamera();
        }


        if (currentHits < hitsBetweenItemDrops)
        {
            currentHits++;
            totalHitsTaken++;
        }
        else
        {
            currentHits = 0;

            // Handle the item drop
            HandleItemDrop();

            DestroyIfMaxHitsReached();
        }
    }

    private void DestroyIfMaxHitsReached()
    {
        if (totalHitsTaken >= maxHits)
        {
            Destroy(gameObject);
        }
    }

    private void HandleItemDrop()
    {
        GameObject itemToDrop = collectables[Random.Range(0, collectables.Length)];
        Transform transform = GetComponent<Transform>();

        Instantiate(itemToDrop, transform.position, Quaternion.identity);
    }
}
