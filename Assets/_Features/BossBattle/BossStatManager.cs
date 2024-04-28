using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatManager : MonoBehaviour
{
    public int bossHealth;
    public GameObject explosion;
    // Start is called before the first frame update
    void Awake()
    {
        bossHealth = 400;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossHealth <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void LoseHealth()
    {
        bossHealth -= 10;
    }
}
