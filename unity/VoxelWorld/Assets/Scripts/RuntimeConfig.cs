using UnityEngine;

public class RuntimeConfig : MonoBehaviour
{
    void Awake()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
        Screen.SetResolution(1280, 800, FullScreenMode.Windowed);
        Application.targetFrameRate = 60;
    }
}
