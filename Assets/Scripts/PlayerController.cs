using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    
    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        var position = Camera.main.WorldToScreenPoint(transform.position);
        var direction = Input.mousePosition - position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Debug.Log(transform.rotation.z);
    }
}
