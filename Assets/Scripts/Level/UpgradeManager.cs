using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Level.Upgrades;
using TMPro;
using Ui;
using UnityEngine;

namespace Level
{
    public class UpgradeManager : MonoBehaviour
    {
        public static UpgradeManager Instance { get; private set; }
        
        public BaseUpgrade[] upgrades;
        public GameObject upgradePanel;
        public TextMeshProUGUI upgradeTitle;
        public RectTransform upgradeItemWrapper;
        public GameObject upgradePrefab;

        private readonly List<GameObject> _spawnedButtons = new();
        private readonly Queue<string> _queuedOpens = new();
        private readonly List<BaseUpgrade> _unlockedUpgrades = new();

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Score.Instance.onLevelUp.AddListener(OnLevelUp);
            _unlockedUpgrades.AddRange(upgrades);
        }

        public void OpenUpgradeScreen(string title)
        {
            StartCoroutine(CoRoutineOpenUpgradeScreen(title));
        }

        private IEnumerator CoRoutineOpenUpgradeScreen(string title)
        {
            if (upgradePanel.activeSelf)
            {
                _queuedOpens.Enqueue(title);
                yield break;
            }
        
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            
            AudioManager.Instance.PlayUpgradeEffect();
            Freezer.Instance.Freeze(FreezeSource.UpgradeScreen);

            upgradeTitle.text = title;
            upgradePanel.SetActive(true);
            
            // Choose three random upgrades
            var random = new System.Random();
            var selected = _unlockedUpgrades.ToList()
                .Where(upgrade => upgrade.Level < upgrade.maxLevel)
                .OrderBy(_ => random.Next()).Take(3);

            // Instantiate the prefabs for each one
            foreach (var upgrade in selected)
            {
                var upgradeBtnObj = Instantiate(upgradePrefab, upgradeItemWrapper);
                var upgradeBtn = upgradeBtnObj.GetComponent<UpgradeButton>();
                upgradeBtn.SetUpgrade(upgrade);

                _spawnedButtons.Add(upgradeBtnObj);
            }
        }
        
        private void OnLevelUp(int level)
        {
            OpenUpgradeScreen("Level Up!");
        }

        public void Close()
        {
            _spawnedButtons.ForEach(Destroy);
            _spawnedButtons.Clear();
            
            upgradePanel.SetActive(false);
            if (_queuedOpens.Count > 0)
            {
                OpenUpgradeScreen(_queuedOpens.Dequeue());
                return;
            }
            
            Freezer.Instance.UnFreeze(FreezeSource.UpgradeScreen);
        }

        public void PushUpgrade(BaseUpgrade upgrade)
        {
            _unlockedUpgrades.Add(upgrade);
        }
    }
}