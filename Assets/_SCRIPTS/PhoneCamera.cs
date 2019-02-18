using UnityEngine;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour
{
    [SerializeField] RawImage background;
    [SerializeField] Renderer screenRenderer;
    //[SerializeField] AspectRatioFitter fitter;

    bool cameraAvailable;
    WebCamTexture backCamera;
    Texture defaultBackground;

    void Start()
    {
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.LogError("No camera detected");
            cameraAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; ++i)
        {
            if (!devices[i].isFrontFacing)
            {
                backCamera = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
                break;
            }
        }

        if (backCamera == null)
        {
            Debug.LogError("Unable to find back camera");
            return;
        }

        //background.texture = backCamera;
        screenRenderer.material.mainTexture = backCamera;
        backCamera.Play();
        cameraAvailable = true;
    }

    //void Update()
    //{
    //    if (!cameraAvailable)
    //    {
    //        return;
    //    }

    //    //float ratio = (float)backCamera.width / backCamera.height;
    //    //fitter.aspectRatio = ratio;

    //    //float scaleY = backCamera.videoVerticallyMirrored ? -1 : 1;
    //    //background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

    //    //int orient = -backCamera.videoRotationAngle;
    //    //background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    //}
}
