using Level;
using Level.Upgrades;
using TMPro;
using Tutorial;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class UpgradeButton : MonoBehaviour
    {
        public TextMeshProUGUI labelText;
        public TextMeshProUGUI descriptionText;
        public TextMeshProUGUI levelText;
        public Image icon;

        private BaseUpgrade _upgrade;

        public void SetUpgrade(BaseUpgrade upgrade)
        {
            labelText.text = upgrade.label;
            descriptionText.text = upgrade.GetUpgradeDescription(upgrade.Level + 1);
            
            levelText.text = upgrade.Level == 0 
                ? "New!" 
                : $"Level {upgrade.Level + 1}";

            if (upgrade.Level == 0)
            {
                levelText.color = new Color(142f / 255f, 0f, 162f / 255f);
            }
                
            icon.sprite = upgrade.sprite;

            _upgrade = upgrade;
        }

        public void Apply()
        {
            AudioManager.Instance.PlayEffectClick();
            
            _upgrade.Upgrade();
            UpgradeManager.Instance.Close();
            TutorialManager.Instance.OnCondition(TutorialCondition.Upgraded);
        }
    }
}