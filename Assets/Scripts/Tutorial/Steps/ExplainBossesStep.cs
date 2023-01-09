using UnityEngine;

namespace Tutorial.Steps
{
    public class ExplainBossesStep : BaseTutorialStep
    {
        public GameObject bossBar;

        public override void OnEnter()
        {
            bossBar.SetActive(true);
        }
    }
}