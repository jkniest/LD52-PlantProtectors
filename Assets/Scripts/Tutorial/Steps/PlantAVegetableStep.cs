using UnityEngine;

namespace Tutorial.Steps
{
    public class PlantAVegetableStep : BaseTutorialStep
    {
        public GameObject pod;

        public override void OnEnter()
        {
            pod.SetActive(true);
        }

        public override bool OnCondition(TutorialCondition condition)
        {
            return condition == TutorialCondition.VegetablePlanted;
        }
    }
}