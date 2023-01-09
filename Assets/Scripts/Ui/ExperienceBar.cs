using Level;
using UnityEngine;

namespace Ui
{
    public class ExperienceBar : MonoBehaviour
    {
        public RectTransform xpBar;
        public RectTransform xpBarWrapper;
        
        private float _xpBarWidth;
        
        private void Start()
        {
            _xpBarWidth = xpBarWrapper.sizeDelta.x;
            Score.Instance.onScoreUpdate.AddListener(OnScoreUpdate);

            Score.Instance.FireEvent();
        }

        private void OnScoreUpdate(ScoreUpdateData data)
        {
            xpBar.sizeDelta = new Vector2(
                _xpBarWidth / data.RequiredTillNextLevel * data.LevelProgress,
                xpBar.sizeDelta.y
            );
        }
    }
}
