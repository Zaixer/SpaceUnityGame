using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const float SpawnChance = 1f / 200f;
    
    void Update()
    {
        SpawnRandomly();
    }

    private void SpawnRandomly()
    {
        var shouldSpawn = Random.value <= SpawnChance;
        if (shouldSpawn)
        {
            var asteroid = Resources.Load<GameObject>("Asteroid");
            var position = new Vector3(Random.Range(-3.6f, 3.6f), transform.position.y);
            var rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            Instantiate(asteroid, position, rotation);
        }
    }
}
