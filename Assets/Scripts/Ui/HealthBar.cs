using TMPro;
using UnityEngine;
using Utilities;

namespace Ui
{
    public class HealthBar : MonoBehaviour
    {
        public Health health;

        public RectTransform healthBar;
        public TextMeshProUGUI healthText;

        private float _healthBarWidth;
        
        private void Start()
        {
            health.onHit.AddListener(OnHit);
            _healthBarWidth = healthBar.sizeDelta.x;
            
            OnHit(health);
        }

        private void OnHit(Health h)
        {
            healthBar.sizeDelta = new Vector2(
                _healthBarWidth / h.maxHealth * h.HealthPoints,
                healthBar.sizeDelta.y
            );

            healthText.text = $"{h.HealthPoints}/{h.maxHealth}";
        }
    }
}