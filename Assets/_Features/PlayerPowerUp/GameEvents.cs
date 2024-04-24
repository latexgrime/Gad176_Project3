using System;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace SAE.GAD176.Project3.LeonardoEstigarribia.EventSystem
{
    public static class GameEvents
    {
        // All events go here.
        public static Action<Collider2D[]> OnPowerUpActivationEvent;
    }
}