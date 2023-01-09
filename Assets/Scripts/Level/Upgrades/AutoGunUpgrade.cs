using UnityEngine;

namespace Level.Upgrades
{
    public class AutoGunUpgrade : BaseUpgrade
    {
        public GameObject autoGun;
        public GameObject autoGun2;
        public GameObject autoGun3;
        public GameObject autoGun4;
        
        public override string GetUpgradeDescription(int level)
        {
            return level switch
            {
                1 => "Add an automatic gun to your base",
                2 => "Decrease shot delay by 50%",
                3 => "Increase turn speed by 50%",
                4 => "Double damage",
                5 => "Add a second auto gun",
                6 => "Decrease shot delay by 75%",
                7 => "Add a third auto gun",
                8 => "Increase turn speed by 100%",
                9 => "Add a fourth auto gun",
                _ => "-"
            };
        }

        protected override void Apply()
        {
            switch (Level)
            {
                case 1: // Add an automatic gun to your base
                    autoGun.SetActive(true);
                    break;
                
                case 2: // Decrease shot delay by 50%
                    Stats.Instance.autoGunFireDelay = .5f;
                    break;
                
                case 3: // Increase turn speed by 50%
                    Stats.Instance.autoGunTurnSpeed = 1.5f / 100f * 150f;
                    break;
                
                case 4: // Double damage
                    Stats.Instance.autoGunDamage = 2;
                    break;
                
                case 5: // Add a second auto gun
                    autoGun2.SetActive(true);
                    break;
                
                case 6: // Decrease shot delay by 75%
                    Stats.Instance.autoGunFireDelay = .25f;
                    break;
                
                case 7: // Add a third auto gun
                    autoGun3.SetActive(true);
                    break;
                
                case 8: // Increase turn speed by 100%
                    Stats.Instance.autoGunTurnSpeed = 1.5f / 100f * 200f;
                    break;
                
                case 9: // Add a fourth auto gun
                    autoGun4.SetActive(true);
                    break;
            }
        }
    }
}