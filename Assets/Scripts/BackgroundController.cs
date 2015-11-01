using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Renderer _renderer;
    private const float SpeedFactor = 0.1f;

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
        _renderer.material.mainTextureOffset = new Vector2(0f, PlayerController.Instance.Position.y * SpeedFactor);
    }
}
