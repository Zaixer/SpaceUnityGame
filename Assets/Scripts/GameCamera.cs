﻿using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public float VerticalOffsetToPlayer = 5f;

    private const float TargetAspectRatio = 9f / 16f;

    void Awake()
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
        if (aspectRatioOfWindow < TargetAspectRatio)
        {
            cameraRect.width = 1f;
            cameraRect.height = aspectRatioOfWindow / TargetAspectRatio;
            cameraRect.x = 0f;
            cameraRect.y = (1f - aspectRatioOfWindow / TargetAspectRatio) / 2f;
        }
        else if (aspectRatioOfWindow > TargetAspectRatio)
        {
            cameraRect.width = aspectRatioOfWindow / TargetAspectRatio;
            cameraRect.height = 1f;
            cameraRect.x = (1f - aspectRatioOfWindow / TargetAspectRatio) / 2f;
            cameraRect.y = 0f;
        }
        camera.rect = cameraRect;
    }

    private void UpdatePositionRelativeToPlayer()
    {
        transform.position = new Vector3(transform.position.x, Player.Instance.Position.y - VerticalOffsetToPlayer);
    }
}
