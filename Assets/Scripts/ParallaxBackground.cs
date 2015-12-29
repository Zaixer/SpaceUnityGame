using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float SpeedFactor = 0.1f;

    private Renderer _renderer;

    void Awake()
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
