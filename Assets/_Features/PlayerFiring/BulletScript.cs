using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Project3.KalyambaMhango.Shoot.Script
{
    public class BulletScript : MonoBehaviour
    {
        public GameObject boss;
        // Start is called before the first frame update
        void Awake()
        {
            Destroy(gameObject, 10);
        }

        // Update is called once per frame
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }

            if (collision.collider.CompareTag("Missile"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            if (collision.collider.CompareTag("Boss"))
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
