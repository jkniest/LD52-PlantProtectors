using UnityEngine;
using Utilities;

namespace Entities
{
    [RequireComponent(typeof(DamageOnHit))]
    public class Bullet : MonoBehaviour
    {
        public float lifeTime = 5f;

        private void Update()
        {
            if (Freezer.Instance.Frozen)
            {
                return;
            }
            
            lifeTime -= Time.deltaTime;
            if (lifeTime < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
