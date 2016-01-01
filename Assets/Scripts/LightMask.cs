using UnityEngine;

public class LightMask : MonoBehaviour
{
    void Update()
    {
        UpdatePositionRelativeToPlayer();
    }

    private void UpdatePositionRelativeToPlayer()
    {
        transform.position = new Vector3(Player.Instance.Position.x, Player.Instance.Position.y);
        transform.rotation = Player.Instance.transform.rotation;
    }
}
