using UnityEngine;

namespace Level.Upgrades
{
    public class PlayerWeaponUpgrade : BaseUpgrade
    {
        public GameObject secondPlayerWeapon;
        public GameObject thirdPlayerWeapon;
        
        private void Start()
        {
            Level = 1;
        }

        public override string GetUpgradeDescription(int level)
        {
            return level switch
            {
                2 => "Decrease shot delay by 25%",
                3 => "Double damage",
                4 => "Decrease shot delay by 50%",
                5 => "Add a second weapon you can control",
                6 => "Increase shot speed by 50%",
                7 => "Decrease shot delay by 75%",
                8 => "Add a third weapon you can control",
                _ => "-"
            };
        }

        protected override void Apply()
        {
            switch (Level)
            {
                case 2: // Decrease shot delay by 25%:
                    Stats.Instance.playerWeaponFireDelay = 0.75f;
                    break;
                
                case 3: // Double damage
                    Stats.Instance.playerWeaponDamage = 2;
                    break;
                
                case 4: // Decrease shot delay by 50%:
                    Stats.Instance.playerWeaponFireDelay = 0.5f;
                    break;
                
                case 5: // Add a second weapon you can control
                    secondPlayerWeapon.SetActive(true);
                    break;
                
                case 6: // Increase shot speed by 50%
                    Stats.Instance.playerWeaponBulletSpeed = 1650;
                    break;
                
                case 7: // Decrease shot delay by 75%:
                    Stats.Instance.playerWeaponFireDelay = 0.25f;
                    break;
                
                case 8: // Add a third weapon you can control
                    thirdPlayerWeapon.SetActive(true);
                    break;
            }
        }
    }
}