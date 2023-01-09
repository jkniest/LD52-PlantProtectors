using UnityEngine;
using Utilities;

namespace Entities
{
    public class ShootingEnemy : Enemy
    {
        public GameObject bulletPrefab;

        private float _cooldown = 2f;
        private float _range = 8f;
        
        private void Update()
        {
            if (Freezer.Instance.Frozen)
            {
                return;
            }

            if (Mathf.Abs(transform.position.z - Base.Base.Instance.transform.position.z) <= _range)
            {
                Fire();
                return;
            }
            
            MoveForward();
        }

        private void Fire()
        {
            _cooldown -= Time.deltaTime;
            if (_cooldown > 0f)
            {
                return;
            }

            _cooldown = 2f;
            var bullet = Instantiate(bulletPrefab, transform.position + (transform.forward * 1.5f), transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1100f);
            bullet.GetComponent<DamageOnHit>().damage = 1;
        }
    }
}