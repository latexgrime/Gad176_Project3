using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject missilePrefab;
    public float moveSpeed = 3f;
    public float detectionRange = 10f;
    public float missileCooldown = 2f;

    private Transform player;
    private float nextFireTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null)
            return;

        // Look for player
        Vector3 direction = player.position - transform.position;
        if (direction.magnitude <= detectionRange)
        {
            // Move towards a random position near the player
            Vector3 randomPosition = player.position + Random.insideUnitSphere * 2;
            randomPosition.y = Random.Range(-1, 4.75f); // Maintain same height
            transform.position = Vector3.MoveTowards(transform.position, randomPosition, moveSpeed * Time.deltaTime);

            // Instantiate missile if cooldown is over
            if (Time.time >= nextFireTime)
            {
                Instantiate(missilePrefab, transform.position, Quaternion.identity);
                nextFireTime = Time.time + missileCooldown;
            }
        }
    }
}
