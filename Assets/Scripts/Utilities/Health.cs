using Tutorial;
using UnityEngine;
using UnityEngine.Events;

namespace Utilities
{
    public class Health : MonoBehaviour
    {
        public int maxHealth = 10;
        public bool destroyOnDeath = true;
        public int regeneratePerSecond = 0;
        public int maxShield = 0;
        public int regenerateShieldPerSecond = 0;

        public int HealthPoints { get; private set; }
        public int ShieldPoints { get; private set; }

        [HideInInspector] public UnityEvent<Health> onHit = new();
        [HideInInspector] public UnityEvent onDeath = new();

        private float _cooldown;

        private void Awake()
        {
            HealthPoints = maxHealth;
            ShieldPoints = maxShield;
        }

        private void Update()
        {
            if (regeneratePerSecond == 0 && regenerateShieldPerSecond == 0)
            {
                return;
            }

            _cooldown -= Time.deltaTime;
            if (_cooldown > 0)
            {
                return;
            }

            _cooldown = 1f;
            Heal(regeneratePerSecond);
            HealShield(regenerateShieldPerSecond);
        }

        public void Heal(int amount)
        {
            if (amount < 0 && ShieldPoints > amount * -1f) // If my shield is greater than the incoming damage
            {
                ShieldPoints += amount;
                amount = 0;
            }

            if (amount < 0)
            {
                amount += ShieldPoints;
                ShieldPoints = 0;
            }

            HealthPoints = Mathf.Min(HealthPoints + amount, maxHealth);

            if (HealthPoints <= 0 && destroyOnDeath)
            {
                onDeath.Invoke();
                Destroy(gameObject);
                return;
            }

            onHit.Invoke(this);
        }

        public void HealShield(int amount)
        {
            ShieldPoints = Mathf.Min(ShieldPoints + amount, maxShield);
            
            onHit.Invoke(this);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var damageOnHit = collision.gameObject.GetComponent<DamageOnHit>();
            if (!damageOnHit)
            {
                return;
            }

            if (damageOnHit.damagingLayer != (damageOnHit.damagingLayer | (1 << gameObject.layer)))
            {
                return;
            }

            damageOnHit.onImpact.Invoke();
            
            if (damageOnHit.destroyOnImpact)
            {
                Destroy(collision.gameObject);
            }

            TutorialManager.Instance.OnCondition(TutorialCondition.EnemyKilled);
            Heal(-damageOnHit.damage);
        }
    }
}