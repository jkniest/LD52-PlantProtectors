using UnityEngine;
using UnityEngine.Events;

namespace Utilities
{
    public class DamageOnHit : MonoBehaviour
    {
        public int damage = 1;
        public bool destroyOnImpact = true;
        public LayerMask damagingLayer;

        public UnityEvent onImpact = new UnityEvent();
    }
}