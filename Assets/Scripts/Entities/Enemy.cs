using Level;
using UnityEngine;
using Utilities;
using Random = UnityEngine.Random;

namespace Entities
{
    [RequireComponent(typeof(Health))]
    public class Enemy : MonoBehaviour
    {
        public AudioClip hitSound;
        
        protected virtual void Start()
        {
            GetComponent<Health>().onHit.AddListener(OnHit);
            GetComponent<Health>().onDeath.AddListener(OnDeath);
        }

        private void Update()
        {
            if (Freezer.Instance.Frozen)
            {
                return;
            }

            MoveForward();
        }

        protected void MoveForward()
        {
            transform.Translate(new Vector3(0, 0, 2f * Time.deltaTime), Space.Self);
        }

        private void OnHit(Health h)
        {
            if (!hitSound)
            {
                return;
            }

            AudioManager.Instance.PlayEffectHit(hitSound);
        }
        
        protected virtual void OnDeath()
        {
            AudioManager.Instance.PlayEffectHit(hitSound);
            
            if (Random.Range(0, 100) > Stats.Instance.enemyXpDropChance)
            {
                return;
            }
            
            Score.Instance.Add(3); 
        }
    }
}