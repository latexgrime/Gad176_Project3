    using System;
    using System.Collections;
using System.Collections.Generic;
using SAE.GAD176.Project3.LeonardoEstigarribia.EventSystem;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyMissiles : MonoBehaviour
{
    [SerializeField] private float explosionRadius;
    [SerializeField] private LayerMask missileLayer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ActivatePowerUp();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
    
    private void ActivatePowerUp()
    {
        Collider2D[] missilesInRadius = Physics2D.OverlapCircleAll(transform.position, explosionRadius, missileLayer);
        
        if (GameEvents.OnPowerUpActivationEvent != null)
        {
            GameEvents.OnPowerUpActivationEvent.Invoke(missilesInRadius);
        }
    }
}
