using TMPro;
using UnityEngine;

namespace Ui
{
    public class BossIncomingText : MonoBehaviour
    {
        public TextMeshProUGUI bossIncomingText;

        private void Update()
        {
            bossIncomingText.richText = true;

            if (EnemySpawner.Instance.BossIsAlive)
            {
                bossIncomingText.text = $"<b><color=#cc0000>Boss Fight!</color></b>";
                return;
            }
         
            var timeLeft = Mathf.RoundToInt(EnemySpawner.Instance.BossCooldown);
            bossIncomingText.text = $"Boss in <b><color=#cc0000>{timeLeft}</color></b> seconds";
        }
    }
}