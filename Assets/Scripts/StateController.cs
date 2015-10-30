using UnityEngine;

public class StateController : MonoBehaviour
{
    public static StateController Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
