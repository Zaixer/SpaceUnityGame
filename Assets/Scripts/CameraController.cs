using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    private const float TARGET_ASPECT_RATIO = 9f / 16f;
    private const float Y_OFFSET_TO_PLAYER = 4f;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ScaleToShowTargetAspectRatioWithBlackBars();
    }

    void Update()
    {
        UpdatePositionRelativeToPlayer();
    }

    private void ScaleToShowTargetAspectRatioWithBlackBars()
    {
        var aspectRatioOfWindow = (float)Screen.width / Screen.height;
        var camera = GetComponent<Camera>();
        var cameraRect = camera.rect;
        if (aspectRatioOfWindow < TARGET_ASPECT_RATIO)
        {
            cameraRect.width = 1f;
            cameraRect.height = aspectRatioOfWindow / TARGET_ASPECT_RATIO;
            cameraRect.x = 0f;
            cameraRect.y = (1f - aspectRatioOfWindow / TARGET_ASPECT_RATIO) / 2f;
        }
        else if (aspectRatioOfWindow > TARGET_ASPECT_RATIO)
        {
            cameraRect.width = aspectRatioOfWindow / TARGET_ASPECT_RATIO;
            cameraRect.height = 1f;
            cameraRect.x = (1f - aspectRatioOfWindow / TARGET_ASPECT_RATIO) / 2f;
            cameraRect.y = 0f;
        }
        camera.rect = cameraRect;
    }

    private void UpdatePositionRelativeToPlayer()
    {
        // TODO
    }
}
