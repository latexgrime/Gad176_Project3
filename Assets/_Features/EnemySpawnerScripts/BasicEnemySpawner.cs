using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Project3.KalyambaMhango.Basic.Enemy.Spawner
{
    public class BasicEnemySpawner : MonoBehaviour
    {
        public GameObject enemyPrefab;
        public Vector2 spawnAreaSize;
        public float spawnInterval = 7f;
        public int maxSpawnCount = 20;
        private int spawnCount = 0;
        public GameObject bossPrefab;

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
}

