using Level;
using UnityEngine;
using Utilities;

namespace Entities
{
    [RequireComponent(typeof(DamageOnHit))]
    public class BossEnemy : Enemy
    {
        protected override void Start()
        {
            base.Start();

            GetComponent<DamageOnHit>().onImpact.AddListener(OnImpact);
        }

        protected override void OnDeath()
        {
            base.OnDeath();

            EnemySpawner.Instance.BossWasKilled();
            UpgradeManager.Instance.OpenUpgradeScreen("Boss defeated!");
        }

        private static void OnImpact()
        {
            EnemySpawner.Instance.BossWasKilled();
        }
    }
}