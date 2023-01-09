using UnityEngine;

namespace Level.Upgrades
{
    public class CropQualityUpgrade : BaseUpgrade
    {
        public override string GetUpgradeDescription(int level)
        {
            return level switch
            {
                1 => "Crops grow 15% faster",
                2 => "Crops grow 25% faster",
                3 => "Double crop XP",
                _ => "-"
            };
        }

        protected override void Apply()
        {
            switch (Level)
            {
                case 1: // Increase crop growth rate by 15%
                    Stats.Instance.growthTime = 2f / 100f * 85f;
                    return;
                case 2: // Increase crop growth rate by 25%
                    Stats.Instance.growthTime = 2f / 100f * 75f;
                    return;
                case 3: // Double crop XP
                    Stats.Instance.cropScoreMultiplier++;
                    return;
                default:
                    Debug.LogWarning($"Upgrade for {label} to level {Level} does not exists!");
                    break;
            }
        }
    }
}