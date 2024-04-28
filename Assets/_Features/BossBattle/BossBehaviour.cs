using UnityEngine;

namespace SAE.GAD176.Project3.KalyambaMhango.Boss.Behaviour
{
    public class BossBehaviour : EnemyBehaviour
    {
        public int missilesPerSalvo = 2;
        public Transform[] missileSpawnPoints;
        protected override void Update()
        {
            base.Update();

        }

        protected override void FireMissiles()
        {
            if (Time.time >= nextFireTime)
            {
                for (int i = 0; i < missilesPerSalvo; i++)
                {
                    Transform randomSpawnPoint = missileSpawnPoints[Random.Range(0, missileSpawnPoints.Length)];
                    Instantiate(missilePrefab, randomSpawnPoint.position, Quaternion.identity);
                }
                nextFireTime = Time.time + missileCooldown;
            }

        }
    }
}

