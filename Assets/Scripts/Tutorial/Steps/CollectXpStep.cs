using UnityEngine;

namespace Tutorial.Steps
{
    public class CollectXpStep : BaseTutorialStep
    {
        public GameObject xpBar;

        public override void OnEnter()
        {
            xpBar.SetActive(true);
        }

        public override bool OnCondition(TutorialCondition condition) => condition == TutorialCondition.LevelUp;
    }
}