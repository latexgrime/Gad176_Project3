using UnityEditor;
using UnityEngine;
using System.Collections;

namespace SAE.GAD176.Project3.KalyambaMhango.Shoot.Script
{
    public class ShootScript : MonoBehaviour
    {
        [SerializeField] Transform bulletSpawnPoint;
        public float bulletSpeed;
        public GameObject bulletPrefab;
        private bool isLoaded;

        public void Start()
        {
            isLoaded = true;
        }
        void Update()
        {
            if (Input.GetMouseButtonDown(0) && isLoaded)
            {
                Shoot();
            }
        }

        void Shoot()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - bulletSpawnPoint.position).normalized;

            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            StartCoroutine(Reload());
        }

        IEnumerator Reload()
        {
            // Wait for 0.5 seconds (or any desired reload time)
            yield return new WaitForSeconds(0.5f);

            // Set the gun as loaded
            isLoaded = true;
        }

    }
}



