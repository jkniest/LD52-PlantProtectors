namespace Level.Upgrades
{
    public class ScannerUpgrade : BaseUpgrade
    {
        public override string GetUpgradeDescription(int level)
        {
            return level switch
            {
                1 => "Increase auto weapon search radius by 20%",
                2 => "Increase auto weapon search radius by 40%",
                3 => "Increase auto weapon search radius by 60%",
                4 => "Increase auto weapon search radius by 80%",
                5 => "Increase auto weapon search radius by 100%",
                _ => ""
            };
        }

        protected override void Apply()
        {
            switch (Level)
            {
                case 1: // Increase auto weapon search radius by 20%
                    Stats.Instance.scannerRadius = Stats.Instance.InitialScannerRadius / 100f * 120f;
                    break;
                
                case 2: // Increase auto weapon search radius by 40%
                    Stats.Instance.scannerRadius = Stats.Instance.InitialScannerRadius / 100f * 140f;
                    break;
                
                case 3: // Increase auto weapon search radius by 60%
                    Stats.Instance.scannerRadius = Stats.Instance.InitialScannerRadius / 100f * 160f;
                    break;
                
                case 4: // Increase auto weapon search radius by 80%
                    Stats.Instance.scannerRadius = Stats.Instance.InitialScannerRadius / 100f * 180f;
                    break;
                
                case 5: // Increase auto weapon search radius by 100%
                    Stats.Instance.scannerRadius = Stats.Instance.InitialScannerRadius / 100f * 200f;
                    break;
            }
        }
    }
}