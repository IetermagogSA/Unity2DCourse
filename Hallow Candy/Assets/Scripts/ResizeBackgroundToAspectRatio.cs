using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeBackgroundToAspectRatio : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject backgroundImage;
    public GameObject objectToResize;
    public Camera mainCamera;

    void Start()
    {
        // Step 1: Get the screen's aspect ratio
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);

        float screenHeight = Screen.height;
        float screenWidth = Screen.width;
        float DEVICE_ASPECT_RATIO = screenWidth / screenHeight;

        // Step 2: Set the aspect ratio of the camera to the aspect ratio of the device
        mainCamera.aspect = DEVICE_ASPECT_RATIO;

        // Step 3: Resize the background to fix the new aspect ratio
        float camHeight = 160.0f * mainCamera.orthographicSize * 2.0f;
        float camWidth = camHeight * DEVICE_ASPECT_RATIO;

        RectTransform backgroundImageSR = backgroundImage.GetComponent<RectTransform>();
        float bgImgH = backgroundImageSR.rect.height;
        float bgImgW = backgroundImageSR.rect.width;

        // Calculate the ratio for scaling...
        float bgImg_scale_ratio_Height = (camHeight / bgImgH);
        float bgImg_scale_ratio_Width = (camWidth / bgImgW);

        objectToResize.transform.localScale = new Vector3(objectToResize.transform.localScale.x* bgImg_scale_ratio_Width, objectToResize.transform.localScale.y * bgImg_scale_ratio_Height, 1);
    }

}
