using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Project3.KalyambaMhango.Shoot.Script
{
    public class BulletScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Awake()
        {
            Destroy(gameObject, 10);
        }

        // Update is called once per frame
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag == "Enemy")
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }

            if (collision.collider.tag == "Missile")
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }

            if (collision.collider.tag == "MissileV2")
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
