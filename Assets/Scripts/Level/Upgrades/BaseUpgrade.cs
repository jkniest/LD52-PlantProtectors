using UnityEngine;

namespace Level.Upgrades
{
    public abstract class BaseUpgrade : MonoBehaviour
    {
        public string label;
        public int maxLevel = 3;
        public Sprite sprite;

        public BaseUpgrade[] unlocks;

        public int Level { get; protected set; }

        public void Upgrade()
        {
            Level = Mathf.Min(Level + 1, maxLevel);
            
            foreach (var unlock in unlocks)
            {
                UpgradeManager.Instance.PushUpgrade(unlock);
            }
            
            Apply();
        }
        
        public abstract string GetUpgradeDescription(int level);
        protected abstract void Apply();
    }
}