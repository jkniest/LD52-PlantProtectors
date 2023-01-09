namespace Tutorial.Steps
{
    public class ChooseAnUpgradeStep : BaseTutorialStep
    {
        public override bool OnCondition(TutorialCondition condition) => condition == TutorialCondition.Upgraded;
    }
}