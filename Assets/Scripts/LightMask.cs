using UnityEngine;

public class LightMask : MonoBehaviour
{
    public float VerticalOffsetToPlayer = 1.5f;

    void Update()
    {
        UpdatePositionRelativeToPlayer();
    }

    private void UpdatePositionRelativeToPlayer()
    {
        transform.position = new Vector3(Player.Instance.Position.x, Player.Instance.Position.y - VerticalOffsetToPlayer);
        transform.rotation = Player.Instance.transform.rotation;
    }
}
