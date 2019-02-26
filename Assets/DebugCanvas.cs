using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class DebugCanvas : MonoBehaviour
{
    [SerializeField] Text debugText;

    void Start()
    {
        VuforiaRuntime.Instance.Deinit();
        if (VuforiaUnity.SetDriverLibrary(Path.Combine(Application.dataPath, "lib", "armeabi-v7a", "libUVCDriver.so")))
        {
            debugText.text = "SetDriverLibrary!";
        }
        VuforiaRuntime.Instance.InitVuforia();
    }
}
