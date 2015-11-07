using UnityEngine;

public class GameBackground : MonoBehaviour
{
    private const float SpeedFactor = 0.1f;
    private Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        UpdateOffsetRelativeToPlayer();
    }

    private void UpdateOffsetRelativeToPlayer()
    {
        _renderer.material.mainTextureOffset = new Vector2(0f, Player.Instance.Position.y * SpeedFactor);
    }
}
