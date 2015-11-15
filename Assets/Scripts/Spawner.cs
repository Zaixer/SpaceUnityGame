using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public abstract float HorizontalSpacing { get; }
    public abstract float VerticalRange { get; }
    public abstract string ResourcePath { get; }
    public abstract bool FirstSpawnSideToggleValue { get; }

    private bool ShouldSpawn { get { return Mathf.Abs(Player.Instance.Position.y) >= _verticalLocationOfLastSpawn + HorizontalSpacing; } }
    private bool _spawnSideToggle;
    private float _verticalLocationOfLastSpawn;

    void Start()
    {
        _spawnSideToggle = FirstSpawnSideToggleValue;
    }

    void Update()
    {
        if (ShouldSpawn)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        var gameObject = Resources.Load<GameObject>(ResourcePath);
        var position = new Vector3(_spawnSideToggle ? Random.Range(-VerticalRange, 0f) : Random.Range(0f, VerticalRange), transform.position.y);
        var rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        Instantiate(gameObject, position, rotation);
        _verticalLocationOfLastSpawn = Mathf.Abs(Player.Instance.Position.y);
        _spawnSideToggle = !_spawnSideToggle;
    }
}
