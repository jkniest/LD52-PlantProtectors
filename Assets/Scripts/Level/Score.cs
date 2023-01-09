using Tutorial;
using UnityEngine;
using UnityEngine.Events;

namespace Level
{
    public class Score : MonoBehaviour
    {
        public static Score Instance { get; private set; }

        public float scoreMultiplier = 1.5f;
    
        [HideInInspector] public UnityEvent<ScoreUpdateData> onScoreUpdate = new();
        [HideInInspector] public UnityEvent<int> onLevelUp = new();

        private float _score;
        private int _currentLevel = 0;
        private float _requiredTillNextLevel = 2;
        private float _levelProgress = 0;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            #if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.F))
            {
                UpgradeManager.Instance.OpenUpgradeScreen("Debug!");
            }
            #endif
        }

        public void Add(float amount)
        {
            AudioManager.Instance.PlayEffectXp();
            amount *= Stats.Instance.xpMultiplier;
            
            _score += amount;
            _levelProgress += amount;

            if (_levelProgress >= _requiredTillNextLevel)
            {
                _currentLevel++;
                _requiredTillNextLevel *= scoreMultiplier;
                _levelProgress = 0;

                TutorialManager.Instance.OnCondition(TutorialCondition.LevelUp);
                onLevelUp.Invoke(_currentLevel);
            }
            
            FireEvent();
        }

        public void FireEvent() => onScoreUpdate.Invoke(new ScoreUpdateData(_score, _levelProgress, _requiredTillNextLevel));
    }
}