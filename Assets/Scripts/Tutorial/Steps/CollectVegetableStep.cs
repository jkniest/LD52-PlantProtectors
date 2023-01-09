namespace Tutorial.Steps
{
    public class CollectVegetableStep : BaseTutorialStep
    {
        public override bool OnCondition(TutorialCondition condition)
        {
            return condition == TutorialCondition.VegetableHarvested;
        }
    }
}