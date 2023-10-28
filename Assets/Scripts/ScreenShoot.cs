using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShoot : MonoBehaviour
{
    public bool screen = false;

    void Update()
    {
        if (screen)
        {
            ScreenCapture.CaptureScreenshot($"Scene{Random.Range(0, 999999)}.png");
            screen = false;
        }
    }
}
