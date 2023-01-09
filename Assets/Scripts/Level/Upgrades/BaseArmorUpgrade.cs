using Utilities;

namespace Level.Upgrades
{
    public class BaseArmorUpgrade : BaseUpgrade
    {
        public Health baseHealth;
        
        public override string GetUpgradeDescription(int level)
        {
            return level switch
            {
                1 => "Increase max health by 20%",
                2 => "Regenerate health over time",
                3 => "Increase max health by 40%",
                4 => "Faster health regeneration",
                5 => "Even faster health regeneration",
                6 => "Increase max health by 60%",
                7 => "Increase max health by 100%",
                _ => "-"
            };
        }

        protected override void Apply()
        {
            switch (Level)
            {
                case 1: // Increase max health by 20%
                    baseHealth.maxHealth = 120;
                    baseHealth.Heal(20);
                    break;
                
                case 2: // Regenerate health over time
                    baseHealth.regeneratePerSecond = 1;
                    break;
                
                case 3: // Increase max health by 40%
                    baseHealth.maxHealth = 140;
                    baseHealth.Heal(20);
                    break;
                
                case 4: // Faster health regeneration
                    baseHealth.regeneratePerSecond = 2;
                    break;
                
                case 5: // Even faster health regeneration
                    baseHealth.regeneratePerSecond = 3;
                    break;
                
                case 6: // Increase max health by 60%
                    baseHealth.maxHealth = 160;
                    baseHealth.Heal(20);
                    break;
                
                case 7: // Increase max health by 100%
                    baseHealth.maxHealth = 200;
                    baseHealth.Heal(40);
                    break;
            }
        }
    }
}
