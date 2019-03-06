using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeTime = 0.2f;
    [SerializeField] float shakeRange = 3f;

    Transform cameraTransform;
    Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        originalPosition = cameraTransform.position;
    }

    public void ShakeTheCamera()
    {
        StartCoroutine(ShakeCamera());
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if(Input.GetMouseButtonDown(0))
    //    {
    //        StartCoroutine(ShakeCamera());
    //    }
    //}

    IEnumerator ShakeCamera()
    {
        float elapsedTime = 0f;
        while(elapsedTime < shakeTime)
        {
            // Shake the camera
            Vector3 pos = originalPosition + Random.insideUnitSphere * shakeRange;
            // Do not move the z-axis
            pos.z = originalPosition.z;

            cameraTransform.position = pos;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        cameraTransform.position = originalPosition;
    }

    private void OnDestroy()
    {
        cameraTransform.position = originalPosition;
    }
}
