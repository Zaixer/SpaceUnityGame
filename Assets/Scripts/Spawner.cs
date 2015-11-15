using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float AsteroidVerticalSpacing = 2f;
    public float AsteroidHorizontalRange = 2.8f;
    public float FuelVerticalSpacing = 10f;
    public float FuelHorizontalRange = 3.3f;
    
    private bool _spawnSideToggle;
    private float _verticalLocationOfLastAsteroidSpawn;
    private float _verticalLocationOfLastFuelSpawn;

    void Update()
    {
        var verticalDistance = Mathf.Abs(Player.Instance.Position.y);
        if (ShouldSpawn(verticalDistance, _verticalLocationOfLastAsteroidSpawn, AsteroidVerticalSpacing))
        {
            Spawn("Asteroid", AsteroidHorizontalRange, _spawnSideToggle);
            _verticalLocationOfLastAsteroidSpawn = verticalDistance;
            if (ShouldSpawn(verticalDistance, _verticalLocationOfLastFuelSpawn, FuelVerticalSpacing))
            {
                Spawn("Fuel", FuelHorizontalRange, !_spawnSideToggle);
                _verticalLocationOfLastFuelSpawn = verticalDistance;
            }
            _spawnSideToggle = !_spawnSideToggle;
        }
    }

    private bool ShouldSpawn(float verticalDistance, float verticalLocationOfLastSpawn, float verticalSpacing)
    {
        return verticalDistance >= verticalLocationOfLastSpawn + verticalSpacing;
    }

    private void Spawn(string resourcePath, float horizontalRange, bool left)
    {
        var gameObject = Resources.Load<GameObject>(resourcePath);
        var position = new Vector3(left ? Random.Range(-horizontalRange, 0f) : Random.Range(0f, horizontalRange), transform.position.y);
        var rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        Instantiate(gameObject, position, rotation);
    }
}
