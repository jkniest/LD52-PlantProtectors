using UnityEngine;
using Utilities;

namespace Base
{
    [RequireComponent(typeof(Health))]
    public class Base : MonoBehaviour
    {
        public static Base Instance { get; private set; }

        public GameObject gameOverScreen;
        
        private Health _health;

        private void Awake()
        {
            Instance = this;
            
            _health = GetComponent<Health>();
            _health.onHit.AddListener(OnHit);
        }

        private void OnHit(Health health)
        {
            if (health.HealthPoints <= 0)
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            Freezer.Instance.Freeze(FreezeSource.GameOver);
            gameOverScreen.SetActive(true);
        }
    }
}