using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public Vector3 Position { get { return transform.position; } }

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        RotateTowardsMousePosition();
    }    

    private void RotateTowardsMousePosition()
    {
        var position = Camera.main.WorldToScreenPoint(transform.position);
        var direction = Input.mousePosition - position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
