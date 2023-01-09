using UnityEngine;
using Utilities;

namespace Weapons
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform bulletSpawnPoint;
        
        protected float Cooldown;

        protected void Shoot(float bulletSpeed, int damage)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
            bullet.GetComponent<DamageOnHit>().damage = damage;
            
            AudioManager.Instance.PlayPewEffect();
            
        }

        protected void RotateTo(Vector3 target, float smoothing = 1f)
        {
            var direction = target - transform.position;
            var rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.Euler(0, rotation, 0),
                smoothing
            );
        }
    }
}