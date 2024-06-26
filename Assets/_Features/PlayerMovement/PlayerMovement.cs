using System;
using System.Collections;
using System.Collections.Generic;
using SAE.GAD176.Project3.LeonardoEstigarribia.EventSystem;
using UnityEngine;

namespace SAE.GAD176.Project3.LeonardoEstigarribia.PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        private float horizontalValue;
        private float playerSpeed = 8f;
        private float jumpingPower = 16f;
        private bool isFacingRight = true;

        private Rigidbody2D rb;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundCheckRadius = .2f;
        [SerializeField] private LayerMask groundLayer;
        
        #region Unity General Scripts
        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            horizontalValue = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            // Longer jumps if the player presses the button for longer.
            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
            
            Flip();
        }

        void FixedUpdate()
        {
            rb.velocity = new Vector2(horizontalValue * playerSpeed, rb.velocity.y);
        }

        #endregion
        
        #region Script Specific Scripts
        private bool isGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }
        
        private void Flip()
        {
            if (isFacingRight && horizontalValue < 0f || !isFacingRight && horizontalValue > 0f)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }

        private void MissileDestroyerPowerUp(Collider2D[] missiles)
        {
            for (int i = 0; i < missiles.Length; i++)
            {
                Debug.Log("Destroying missiles.");
                Destroy(missiles[i].gameObject);
            }
        }

        private void OnEnable()
        {
            GameEvents.OnPowerUpActivationEvent += MissileDestroyerPowerUp;
        }

        private void OnDisable()
        {
            GameEvents.OnPowerUpActivationEvent -= MissileDestroyerPowerUp;
        }

        #endregion
    }
}


