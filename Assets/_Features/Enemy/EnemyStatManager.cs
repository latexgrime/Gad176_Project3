using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatManager : MonoBehaviour
{
    public float enemyHealth;

    void Awake()
    {
        enemyHealth = 100;
    }

    void LoseHealth()
    {
        enemyHealth -= 10;
    }

    void Die()
    {
        if (enemyHealth > 0)
        {
            Destroy(gameObject);
        }
    }
}
