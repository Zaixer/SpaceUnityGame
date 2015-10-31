using UnityEngine;

public class ColliderController : MonoBehaviour
{
    void Update()
    {
        UpdatePositionRelativeToPlayer();
    }

    private void UpdatePositionRelativeToPlayer()
    {
        transform.position = new Vector3(transform.position.x, PlayerController.Instance.Position.y);
    }
}
