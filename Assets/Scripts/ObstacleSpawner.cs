using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Prefab
    public float spawnInterval = 2f; // Generate interval（second）
    public float minX = -6f, maxX = 6f, minY = -3f, maxY = 3f; // Generate area

    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnObstacle()
    {
        if (obstaclePrefab == null)
        {
            Debug.LogError("Obstacle Prefab is not assigned！");
            return;
        }

        // Random generation position
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        // Generate obstacle
        //Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Destroy the obstacle after 3 seconds
        Destroy(newObstacle, 3f);
    }
}
