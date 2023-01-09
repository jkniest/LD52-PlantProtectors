using TMPro;
using UnityEngine;
using Utilities;

namespace Ui
{
    public class ShieldBar : MonoBehaviour
    {
        public Health health;

        public RectTransform shieldBar;
        public TextMeshProUGUI shieldText;

        private float _shieldBarWidth;
        
        private void Start()
        {
            health.onHit.AddListener(OnHit);
            _shieldBarWidth = shieldBar.sizeDelta.x;
            
            OnHit(health);
        }

        private void OnHit(Health h)
        {
            shieldBar.sizeDelta = new Vector2(
                _shieldBarWidth / h.maxShield * h.ShieldPoints,
                shieldBar.sizeDelta.y
            );

            shieldText.text = $"{h.ShieldPoints}/{h.maxShield}";
        }
    }
}