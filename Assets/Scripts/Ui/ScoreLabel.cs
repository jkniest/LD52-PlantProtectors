using TMPro;
using UnityEngine;

namespace Ui
{
    public class ScoreLabel : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;

        private void Update()
        {
            var minutes = (int)(TimeManager.Instance.Time / 60);
            var seconds = (int)(TimeManager.Instance.Time % 60);

            scoreText.text = minutes + ":" + seconds.ToString("D2");
        }
    }
}