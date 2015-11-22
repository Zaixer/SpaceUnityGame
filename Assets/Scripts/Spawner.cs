using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float AsteroidVerticalSpacing = 2f;
    public float AsteroidHorizontalRange = 2.8f;
    public float FuelVerticalSpacing = 10f;
    public float FuelHorizontalRange = 3.3f;

    private const int AsteroidPoolSize = 10;
    private const int FuelPoolSize = 2;
    private bool _spawnSideToggle;
    private float _verticalLocationOfLastAsteroidSpawn;
    private float _verticalLocationOfLastFuelSpawn;
    private List<GameObject> _asteroidPool;
    private List<GameObject> _fuelPool;

    void Awake()
    {
        _asteroidPool = GetPool("Asteroid", AsteroidPoolSize);
        _fuelPool = GetPool("Fuel", FuelPoolSize);
    }

    void Update()
    {
        var verticalDistance = Mathf.Abs(Player.Instance.Position.y);
        if (ShouldSpawn(verticalDistance, _verticalLocationOfLastAsteroidSpawn, AsteroidVerticalSpacing))
        {
            Spawn(_asteroidPool, AsteroidHorizontalRange, _spawnSideToggle);
            _verticalLocationOfLastAsteroidSpawn = verticalDistance;
            if (ShouldSpawn(verticalDistance, _verticalLocationOfLastFuelSpawn, FuelVerticalSpacing))
            {
                Spawn(_fuelPool, FuelHorizontalRange, !_spawnSideToggle);
                _verticalLocationOfLastFuelSpawn = verticalDistance;
            }
            _spawnSideToggle = !_spawnSideToggle;
        }
    }

    private List<GameObject> GetPool(string resourcePath, int size)
    {
        var pool = new List<GameObject>();
        for (var i = 0; i < size; i++)
        {
            var gameObjectToAdd = Instantiate(Resources.Load<GameObject>(resourcePath));
            gameObjectToAdd.SetActive(false);
            pool.Add(gameObjectToAdd);
        }
        return pool;
    }

    private bool ShouldSpawn(float verticalDistance, float verticalLocationOfLastSpawn, float verticalSpacing)
    {
        return verticalDistance >= verticalLocationOfLastSpawn + verticalSpacing;
    }

    private void Spawn(List<GameObject> pool, float horizontalRange, bool left)
    {
        var gameObjectToSpawn = pool.First(x => !x.activeSelf);
        gameObjectToSpawn.transform.position = new Vector3(left ? Random.Range(-horizontalRange, 0f) : Random.Range(0f, horizontalRange), transform.position.y);
        gameObjectToSpawn.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        gameObjectToSpawn.SetActive(true);
    }
}
