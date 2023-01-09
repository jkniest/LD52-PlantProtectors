using UnityEngine;
using Utilities;

namespace Level.Upgrades
{
    public class ShieldUpgrade : BaseUpgrade
    {
        public GameObject shieldBar;
        public Health baseHealth;
        
        public override string GetUpgradeDescription(int level)
        {
            return level switch
            {
                1 => "Add a shield to your base",
                2 => "Increase shield by 50%",
                3 => "Double shield regeneration speed",
                4 => "Increase shield by 100%",
                5 => "Triple shield regeneration speed",
                6 => "Increase shield by 200%",
                _ => "-"
            };
        }

        protected override void Apply()
        {
            switch (Level)
            {
                case 1: // Add a shield to your base
                    shieldBar.SetActive(true);
                    
                    baseHealth.maxShield = 10;
                    baseHealth.regenerateShieldPerSecond = 1;
                    baseHealth.HealShield(10);

                    break;
                
                case 2: // Increase shield by 50%
                    baseHealth.maxShield = 15;
                    baseHealth.HealShield(15);
                    break;
                
                case 3: // Double shield regeneration speed
                    baseHealth.regenerateShieldPerSecond = 2;
                    break;
                
                case 4: // Increase shield by 100%
                    baseHealth.maxShield = 20;
                    baseHealth.HealShield(20);
                    break;
                
                case 5: // Triple shield regeneration speed
                    baseHealth.regenerateShieldPerSecond = 3;
                    break;
                
                case 6: // Increase shield by 200% 
                    baseHealth.maxShield = 40;
                    baseHealth.HealShield(40);
                    break;
            }
        }
    }
}