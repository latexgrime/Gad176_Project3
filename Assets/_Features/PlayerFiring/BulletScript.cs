using SAE.GAD176.Project3.KalyambaMhango.Boss.Stat.Manager;
using SAE.GAD176.Project3.KalyambaMhango.Score.Board;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Project3.KalyambaMhango.Bullet.Script
{
   public class BulletScript : MonoBehaviour
{
    public GameObject boss;
    private Scoreboard scoreboard;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, 5);
        scoreboard = FindObjectOfType(typeof(Scoreboard)) as Scoreboard;
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            if (scoreboard != null)
            {
                scoreboard.IncrementScore(1);
            }
        }

        else if (collision.collider.CompareTag("Missile"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            if (scoreboard != null)
            {
                scoreboard.IncrementScore(1);
            }
        }
        else if (collision.collider.CompareTag("Boss"))
        {
            GameObject hitBoss = collision.gameObject;
            BossStatManager bossHealth = hitBoss.GetComponent<BossStatManager>();
            if (hitBoss != null)
            {
                bossHealth.LoseHealth();
            }
            Destroy(gameObject);
        }
    }
}
}


