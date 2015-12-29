using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float MineVerticalSpacing = 2f;
    public float MineHorizontalRange = 2.8f;
    public float FuelVerticalSpacing = 10f;
    public float FuelHorizontalRange = 3.3f;

    private const int MinePoolSize = 10;
    private const int FuelPoolSize = 2;
    private bool _spawnSideToggle;
    private float _verticalLocationOfLastMineSpawn;
    private float _verticalLocationOfLastFuelSpawn;
    private List<GameObject> minePool;
    private List<GameObject> _fuelPool;

    void Awake()
    {
        minePool = GetPool(MinePoolSize, "Mine1", "Mine2");
        _fuelPool = GetPool(FuelPoolSize, "Fuel");
    }

    void Update()
    {
        var verticalDistance = Mathf.Abs(Player.Instance.Position.y);
        if (ShouldSpawn(verticalDistance, _verticalLocationOfLastMineSpawn, MineVerticalSpacing))
        {
            Spawn(minePool, MineHorizontalRange, _spawnSideToggle);
            _verticalLocationOfLastMineSpawn = verticalDistance;
            if (ShouldSpawn(verticalDistance, _verticalLocationOfLastFuelSpawn, FuelVerticalSpacing))
            {
                Spawn(_fuelPool, FuelHorizontalRange, !_spawnSideToggle);
                _verticalLocationOfLastFuelSpawn = verticalDistance;
            }
            _spawnSideToggle = !_spawnSideToggle;
        }
    }

    private List<GameObject> GetPool(int size, params string[] resourcePaths)
    {
        var pool = new List<GameObject>();
        var resourcePathIndex = 0;
        for (var i = 0; i < size; i++)
        {
            var gameObjectToAdd = Instantiate(Resources.Load<GameObject>(resourcePaths[resourcePathIndex]));
            gameObjectToAdd.SetActive(false);
            pool.Add(gameObjectToAdd);
            resourcePathIndex = resourcePathIndex + 1 < resourcePaths.Length ? resourcePathIndex + 1 : 0;
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
