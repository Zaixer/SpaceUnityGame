using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public Vector3 Position { get { return transform.position; } }
    public bool IsAlive { get { return _isAlive; } }
    public GameObject EndOptionsPanel;
    public float MinAngle = 181f;
    public float MaxAngle = 359f;
    public float MaxAngleChangePerFrame = 10f;

    private ConstantForce2D _constantForce2D;
    private bool _isAlive = true;

    void Awake()
    {
        Instance = this;
        _constantForce2D = GetComponent<ConstantForce2D>();
    }

    void Update()
    {
        if (_isAlive)
        {
            RotateTowardsPointer();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (_isAlive)
        {
            switch (GameObjectHelper.GetOriginalResourceName(other.gameObject))
            {
                case "Fuel":
                    Fuel.Instance.IncreaseFuel();
                    other.gameObject.SetActive(false);
                    break;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isAlive)
        {
            switch (GameObjectHelper.GetOriginalResourceName(collision.gameObject))
            {
                case "Mine1":
                case "Mine2":
                    EndGame();
                    break;
            }
        }
    }

    public void EndGame()
    {
        _constantForce2D.relativeForce = new Vector2(0f, 0f);
        _isAlive = false;
        EndOptionsPanel.SetActive(true);
        Score.Instance.SetEndScore();
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
