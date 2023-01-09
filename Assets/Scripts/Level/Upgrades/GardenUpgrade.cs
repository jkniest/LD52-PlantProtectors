using UnityEngine;

namespace Level.Upgrades
{
    public class GardenUpgrade : BaseUpgrade
    {
        public GameObject[] podsRow1;
        public GameObject[] podsRow2;
        public GameObject[] podsRow3;
        
        public override string GetUpgradeDescription(int level)
        {
            return level switch
            {
                1 => "Add two more garden pods",
                2 => "Add a second row to your garden pods", 
                3 => "Add a third row to your garden pods",
                _ => "-"
            };
        }

        protected override void Apply()
        {
            switch (Level)
            {
                case 1: // Add two more garden pods
                    foreach (var pod in podsRow1)
                    {
                        pod.SetActive(true);
                    }
                    break;
                
                case 2: // Add a second row to your garden pods
                    foreach (var pod in podsRow2)
                    {
                        pod.SetActive(true);
                    }
                    break;
                
                case 3: // Add a third row to your garden pods
                    foreach (var pod in podsRow3)
                    {
                        pod.SetActive(true);
                    }
                    break;
            }
        }
    }
}