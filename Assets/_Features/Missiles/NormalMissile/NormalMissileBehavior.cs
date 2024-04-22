using UnityEngine;

namespace SAE.GAD176.Project3.LeonardoEstigarribia.NormalMissile.Behavior
{
    public class NormalMissileBehavior : MonoBehaviour
    {
        private Transform target;
        private float normalMissileSpeed;
        private const float NormalMissileSpeedMultiplier = 0.8f;
        private readonly float normalMissileRotationSpeed = 250f;

        private Vector2 direction;
        private Rigidbody2D rb;

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region Unity General Functions

        protected void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            target = GameObject.FindWithTag("Player").transform;
            // Gets the ScoreCounter component from the HUD Holder game object.
        }

        protected virtual void FixedUpdate()
        {
            if (target)
            {
                CalculateMissileDirectionAndSpeed();
                RotateMissile(normalMissileSpeed, normalMissileRotationSpeed);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region Script Specific Functions

        // Direction in which missile should be facing.
        protected void CalculateMissileDirectionAndSpeed()
        {
            if (target)
            {
                direction = (Vector2)target.position - rb.position;

                // If the distance is higher than X units (in this case 7), accelerate the missile.
                if (direction.magnitude > 5)
                    normalMissileSpeed = direction.magnitude * NormalMissileSpeedMultiplier;
                else
                    normalMissileSpeed = 12f;

                direction.Normalize();
            }
        }

        // Missile rotation formula.
        protected void RotateMissile(float missileSpeed, float missileRotationSpeed)
        {
            // Length of cross product that knows if the missile needs to rotate and in which direction.

            var rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotateAmount * missileRotationSpeed;
            rb.velocity = transform.up * missileSpeed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            switch (collision.gameObject.tag)
            {
                // If the missile collides with a player, destroy missile and destroy player.
                case "Player":
                    Debug.Log("Player was killed by " + gameObject.name);
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                    break;
                // If the missile colliders with another missile, destroy both missiles.
                case "Missile":
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                    break;
            }
        }

        #endregion
    }
}