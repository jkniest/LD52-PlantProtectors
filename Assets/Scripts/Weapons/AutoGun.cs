using System.Linq;
using Level;
using Unity.VisualScripting;
using UnityEngine;

namespace Weapons
{
    public class AutoGun : BaseWeapon
    {
        public LayerMask enemyLayerMask;

        public GameObject target;

        private void Update()
        {
            if (Freezer.Instance.Frozen)
            {
                return;
            }

            LookAtNearestEnemy();
            Fire();
        }

        private void LookAtNearestEnemy()
        {
            var enemies = new Collider[256];
            
            // Physic Check 
            var enemyCount = Physics.OverlapSphereNonAlloc(
                transform.position,
                Stats.Instance.scannerRadius,
                enemies,
                enemyLayerMask
            );

            if (enemyCount == 0)
            {
                target = null;
                return;
            }

            target = enemies
                .NotNull()
                .OrderBy(enemy => Vector3.Distance(enemy.transform.position, transform.position))
                .First()
                .gameObject;

            RotateTo(target.transform.position, Stats.Instance.autoGunTurnSpeed * Time.deltaTime);
        }

        private void Fire()
        {
            Cooldown -= Time.deltaTime;
            if (Cooldown > 0f || target == null)
            {
                return;
            }

            Cooldown = Stats.Instance.autoGunFireDelay;
            Shoot(Stats.Instance.autoGunBulletSpeed, Stats.Instance.autoGunDamage);
        }
    }
}