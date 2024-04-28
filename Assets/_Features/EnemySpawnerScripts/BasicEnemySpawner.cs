using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector2 spawnAreaSize;
    public float spawnInterval = 7f;
    public int maxSpawnCount = 20; // Maximum number of enemies to spawn

    private int spawnCount = 0; // Counter for the number of enemies spawned

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (spawnCount < maxSpawnCount)
        {
            yield return new WaitForSeconds(spawnInterval);

            Vector3 spawnPosition = new(
                Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
                Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f),
                0f);

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            spawnCount++;
        }
    }
}

