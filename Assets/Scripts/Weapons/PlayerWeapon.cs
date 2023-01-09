using Level;
using UnityEngine;

namespace Weapons
{
    public class PlayerWeapon : BaseWeapon
    {
        public Camera mainCamera;
        
        private void Update()
        {
            if (Freezer.Instance.Frozen)
            {
                return;
            }
        
            if (Input.mousePosition.x > Screen.width / 2f)
            {
                return;
            }
        
            LookAtMouse();
            Fire();
        }

        private void LookAtMouse()
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            var plane = new Plane(Vector3.up, Vector3.zero);
            if (!plane.Raycast(ray, out var distance))
            {
                return;
            }

            RotateTo(ray.GetPoint(distance));
        }

        private void Fire()
        {
            Cooldown -= Time.deltaTime;
            if (!Input.GetMouseButton(0) || Cooldown > 0f)
            {
                return;
            }

            Cooldown = Stats.Instance.playerWeaponFireDelay;
            Shoot(Stats.Instance.playerWeaponBulletSpeed, Stats.Instance.playerWeaponDamage);
        }
    }
}