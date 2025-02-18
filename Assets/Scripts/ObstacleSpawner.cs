using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; 
    public float spawnInterval = 5f;
    public float minX = -6f, maxX = 6f, minY = -3f, maxY = 3f;

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

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        float randomRotation = Random.Range(0f, 360f);
        Quaternion spawnRotation = Quaternion.Euler(0, 0, randomRotation);

        GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, spawnRotation);

        Destroy(newObstacle, 5f);
    }
}
