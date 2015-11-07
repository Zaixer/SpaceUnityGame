using UnityEngine;

public class RotationHelper
{
    public static float GetRotationAngleAroundZInDegrees(float x, float y)
    {
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        if (angle < 0)
        {
            angle += 360;
        }
        return angle;
    }
}
