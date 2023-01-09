namespace Level.Upgrades
{
    public class ExperienceUpgrade : BaseUpgrade
    {
        public override string GetUpgradeDescription(int level)
        {
            return level switch
            {
                1 => "Increase all xp by 20%",
                2 => "Increase all xp by 30%",
                3 => "Enemies have a 5% chance to drop xp",
                4 => "Increase all xp by 40%",
                5 => "Enemies have a 10% chance to drop xp",
                6 => "Enemies have a 20% chance to drop xp",
                7 => "Increase all xp by 60%",
                8 => "Enemies have a 30% chance to drop xp",
                9 => "Increase all xp by 80%",
                10 => "Enemies have a 40% chance to drop xp",
                11 => "Increase all xp by 100%",
                _ => "-"
            };
        }

        protected override void Apply()
        {
            switch (Level)
            {
                case 1: // Increase all xp by 20%
                    Stats.Instance.xpMultiplier = Stats.Instance.InitialXpMultiplier / 100f * 120f; 
                    break;
                
                case 2: // Increase all xp by 30%
                    Stats.Instance.xpMultiplier = Stats.Instance.InitialXpMultiplier / 100 * 130;
                    break;
                
                case 3: // Enemies have a 5% chance to drop xp
                    Stats.Instance.enemyXpDropChance = 5;
                    break;
                
                case 4: // Increase all xp by 40%
                    Stats.Instance.xpMultiplier = Stats.Instance.InitialXpMultiplier / 100 * 140;
                    break;
                
                case 5: // Enemies have a 10% chance to drop xp
                    Stats.Instance.enemyXpDropChance = 10;
                    break;
                
                case 6: // Enemies have a 20% chance to drop xp
                    Stats.Instance.enemyXpDropChance = 20;
                    break;
                
                case 7: // Increase all xp by 60%
                    Stats.Instance.xpMultiplier = Stats.Instance.InitialXpMultiplier / 100 * 160;
                    break;
                
                case 8: // Enemies have a 30% chance to drop xp
                    Stats.Instance.enemyXpDropChance = 30;
                    break;
                
                case 9: // Increase all xp by 80%
                    Stats.Instance.xpMultiplier = Stats.Instance.InitialXpMultiplier / 100 * 180;
                    break;
                
                case 10: // Enemies have a 40% chance to drop xp 
                    Stats.Instance.enemyXpDropChance = 40;
                    break;
                
                case 11: // Increase all xp by 100%
                    Stats.Instance.xpMultiplier = Stats.Instance.InitialXpMultiplier / 100 * 200;
                    break;
            }
        }
    }
}