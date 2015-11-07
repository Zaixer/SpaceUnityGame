using UnityEngine;

public class Setup : MonoBehaviour
{
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
