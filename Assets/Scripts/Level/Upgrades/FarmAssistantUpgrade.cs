using Base;

namespace Level.Upgrades
{
    public class FarmAssistantUpgrade : BaseUpgrade
    {
        public Pod[] pods;
        
        public override string GetUpgradeDescription(int level)
        {
            return "Fully automates one garden pot";
        }

        protected override void Apply()
        {
            pods[Level - 1].EnableHelper();
        }
    }
}