using Level;
using Tutorial;
using UnityEngine;

namespace Base
{
    public class Pod : MonoBehaviour
    {
        public SpriteRenderer spriteRenderer;
        public GameObject helper;
        
        private Vegetable _planted;
        private int _growthLevel;
        private float _cooldown;
        private bool _helperActive;

        private void Update()
        {
            if (Freezer.Instance.Frozen)
            {
                return;
            }
            
            UpdateGrowthLevel();
            HandleHelper();
            Render();
        }

        private void HandleHelper()
        {
            if (!_helperActive)
            {
                return;
            }
            
            if (!_planted)
            {
                _planted = Stats.Instance.cropToBePlanted;
                _cooldown = Stats.Instance.growthTime;
                _growthLevel = 0;
                AudioManager.Instance.PlayEffectPlant();
                return;
            }

            if (_growthLevel < 3)
            {
                return;
            }

            Score.Instance.Add(_planted.score * Stats.Instance.cropScoreMultiplier);

            _planted = null;
            _growthLevel = 0;
        }

        private void UpdateGrowthLevel()
        {
            if (_growthLevel >= 3)
            {
                return;
            }

            _cooldown -= Time.deltaTime;
            if (_cooldown > 0)
            {
                return;
            }

            _growthLevel++;
            _cooldown = Stats.Instance.growthTime;
        }

        private void OnMouseDown()
        {
            if (_helperActive)
            {
                return;
            }
            
            if (!_planted)
            {
                _planted = Stats.Instance.cropToBePlanted;
                _cooldown = Stats.Instance.growthTime;
                _growthLevel = 0;
                AudioManager.Instance.PlayEffectPlant();
                TutorialManager.Instance.OnCondition(TutorialCondition.VegetablePlanted);
                return;
            }

            if (_growthLevel < 3)
            {
                return;
            }

            Score.Instance.Add(_planted.score * Stats.Instance.cropScoreMultiplier);

            _planted = null;
            _growthLevel = 0;
            TutorialManager.Instance.OnCondition(TutorialCondition.VegetableHarvested);
        }

        private void Render()
        {
            if (!_planted)
            {
                spriteRenderer.sprite = null;
                return;
            }

            spriteRenderer.sprite = _planted.sprites[_growthLevel];
        }

        public void EnableHelper()
        {
            helper.SetActive(true);
            _helperActive = true;
        }
    }
}