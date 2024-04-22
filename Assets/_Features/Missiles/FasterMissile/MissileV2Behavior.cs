using SAE.GAD176.Project3.LeonardoEstigarribia.NormalMissile.Behavior;
using UnityEngine;

namespace SAE.GAD176.Project3.LeonardoEstigarribia.MissileV2.Behavior
{
    public class MissileV2Behavior : NormalMissileBehavior
    {
        private readonly float fastMissileSpeed = 8f;
        private readonly float fastMissileRotationSpeed = 150;

        private float selfDestructTime = 5f;
        
        

        #region Unity General Functions

        protected override void Update()
        {
            base.Update();
            Invoke("SelfDestruct", selfDestructTime);
        }

        protected override void FixedUpdate()
        {
            RotateMissile(fastMissileSpeed, fastMissileRotationSpeed);
        }

        #endregion
        
        #region Script Specific Functions

        protected override void CalculateMissileDirectionAndSpeed()
        {
            direction = (Vector2)target.position - rb.position;
            direction.Normalize();
        }

        #endregion
    }
}