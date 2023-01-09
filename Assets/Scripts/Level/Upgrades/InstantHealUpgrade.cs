using Utilities;

namespace Level.Upgrades
{
    public class InstantHealUpgrade : BaseUpgrade
    {
        public Health baseHealth;
        
        public override string GetUpgradeDescription(int level)
        {
            return "Instantly fully heal!";
        }

        protected override void Apply()
        {
            baseHealth.Heal(baseHealth.maxHealth);
        }
    }
}