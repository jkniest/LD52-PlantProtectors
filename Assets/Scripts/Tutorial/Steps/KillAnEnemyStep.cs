using UnityEngine;

namespace Tutorial.Steps
{
    public class KillAnEnemyStep : BaseTutorialStep
    {
        public Transform spawnPoint;
        public GameObject enemyPrefab;
        
        public override void OnEnter()
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }

        public override bool OnCondition(TutorialCondition condition) => condition == TutorialCondition.EnemyKilled;
    }
}