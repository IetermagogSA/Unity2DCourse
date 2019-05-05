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
        print(screenSize);

        float screenHeight = Screen.height;
        float screenWidth = Screen.width;
        float DEVICE_ASPECT_RATIO = screenWidth / screenHeight;
        print("DEVICE ASPECT RATIO: " + DEVICE_ASPECT_RATIO.ToString());

        // Step 2: Set the aspect ratio of the camera to the aspect ratio of the device
        mainCamera.aspect = DEVICE_ASPECT_RATIO;

        // Step 3: Resize the background to fix the new aspect ratio
        float camHeight = 160.0f * mainCamera.orthographicSize * 2.0f;
        float camWidth = camHeight * DEVICE_ASPECT_RATIO;

        print("camHeight: " + camHeight.ToString());
        print("camWidth: " + camWidth.ToString());

        RectTransform backgroundImageSR = backgroundImage.GetComponent<RectTransform>();
        float bgImgH = backgroundImageSR.rect.height;
        float bgImgW = backgroundImageSR.rect.width;

        print("bgImgH: " + bgImgH.ToString());
        print("bgImgW: " + bgImgW.ToString());

        // Calculate the ratio for scaling...
        float bgImg_scale_ratio_Height = (camHeight / bgImgH);
        float bgImg_scale_ratio_Width = (camWidth / bgImgW);

        print("bgImg_scale_ratio_Height: " + bgImg_scale_ratio_Height.ToString());
        print("bgImg_scale_ratio_Width: " + bgImg_scale_ratio_Width.ToString());

        objectToResize.transform.localScale = new Vector3(objectToResize.transform.localScale.x* bgImg_scale_ratio_Width, objectToResize.transform.localScale.y * bgImg_scale_ratio_Height, 1);
    }

}
