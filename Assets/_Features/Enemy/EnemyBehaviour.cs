using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject missilePrefab;
    public float moveSpeed = 3f;
    public float detectionRange = 10f;
    public float missileCooldown = 2f;

    protected Transform player;
    protected float nextFireTime;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void Update()
    {
        if (player == null)
            return;

        // Look for player
        Vector3 direction = player.position - transform.position;
        if (direction.magnitude <= detectionRange)
        {
            // Move towards the player
            MoveAbovePlayer();

            // Instantiate missile if cooldown is over
            FireMissiles();
        }
    }

    protected virtual void MoveAbovePlayer()
    {
        // Look for player
        Vector3 direction = player.position - transform.position;
        if (direction.magnitude <= detectionRange)
        {
            Vector3 randomPosition = player.position + Random.insideUnitSphere * 2;
            randomPosition.y = Random.Range(-1, 4.75f); // Maintain same height area blah blah blah
            transform.position = Vector3.MoveTowards(transform.position, randomPosition, moveSpeed * Time.deltaTime);
        }
    }

    protected virtual void FireMissiles()
    {
        if (Time.time >= nextFireTime)
        {
            Instantiate(missilePrefab, transform.position, Quaternion.identity);
            nextFireTime = Time.time + missileCooldown;
        }
    }

    // Other methods...
}
