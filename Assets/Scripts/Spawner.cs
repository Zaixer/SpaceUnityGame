using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const float AsteroidHorizontalSpacing = 3f;
    private const float AsteroidVerticalRange = 2.6f;
    private bool _asteroidSpawnSideToggle;
    private float _horizontalLocationOfLastAsteroidSpawn;
    
    void Update()
    {
        CheckAsteroidSpawning();
    }

    private void CheckAsteroidSpawning()
    {
        var shouldSpawn = Mathf.Abs(Player.Instance.Position.y) >= _horizontalLocationOfLastAsteroidSpawn + AsteroidHorizontalSpacing;
        if (shouldSpawn)
        {
            var asteroid = Resources.Load<GameObject>("Asteroid");
            var position = new Vector3(_asteroidSpawnSideToggle ? Random.Range(-AsteroidVerticalRange, 0f) : Random.Range(0f, AsteroidVerticalRange), transform.position.y);
            var rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            Instantiate(asteroid, position, rotation);
            _horizontalLocationOfLastAsteroidSpawn = Mathf.Abs(Player.Instance.Position.y);
            _asteroidSpawnSideToggle = !_asteroidSpawnSideToggle;
        }
    }
}
