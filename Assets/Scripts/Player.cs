using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public Vector3 Position { get { return transform.position; } }

    private const float MinAngle = 200f;
    private const float MaxAngle = 340f;
    private const float MaxAngleChangePerFrame = 10f;
    private const float FuelIncreasePerPickup = 100f;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        RotateTowardsPointer();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (GameObjectHelper.GetOriginalResourceName(other.gameObject))
        {
            case "Fuel":
                Fuel.Instance.IncreaseFuel(FuelIncreasePerPickup);
                Destroy(other.gameObject);
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (GameObjectHelper.GetOriginalResourceName(collision.gameObject))
        {
            case "Asteroid":
                Application.LoadLevel("Menu");
                break;
        }
    }

    private void RotateTowardsPointer()
    {
        var newAngle = GetNewAngle();
        transform.rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
    }

    private float GetNewAngle()
    {
        var oldAngle = transform.eulerAngles.z;
        var angleToPointer = GetAngleToPointer();
        if (angleToPointer > oldAngle || angleToPointer < 90f)
        {
            if (angleToPointer < 90f)
            {
                return Mathf.Min(oldAngle + MaxAngleChangePerFrame, MaxAngle);
            }
            return Mathf.Min(oldAngle + MaxAngleChangePerFrame, angleToPointer, MaxAngle);
        }
        if (angleToPointer < oldAngle || angleToPointer > 90f)
        {
            return Mathf.Max(oldAngle - MaxAngleChangePerFrame, angleToPointer, MinAngle);
        }
        return oldAngle;
    }

    private float GetAngleToPointer()
    {
        var directionToPointer = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angleToPointer = RotationHelper.GetRotationAngleAroundZInDegrees(directionToPointer.x, directionToPointer.y);
        return angleToPointer;
    }
}
