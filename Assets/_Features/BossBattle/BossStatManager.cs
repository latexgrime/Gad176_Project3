using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SAE.GAD176.Project3.KalyambaMhango.Boss.Stat.Manager
{
    public class BossStatManager : MonoBehaviour
    {
        public int bossHealth;
        public GameObject explosion;
        public TextMeshProUGUI bossHealthText;

        void Awake()
        {
            bossHealth = 400;
        }

        // Update is called once per frame
        void Update()
        {
            bossHealthText.text = ("Health " + bossHealth);
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
}


