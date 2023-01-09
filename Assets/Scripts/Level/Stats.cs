using Base;
using UnityEngine;

namespace Level
{
    public class Stats : MonoBehaviour
    {
        public static Stats Instance { get; private set; }

        #region CROPS
        public float growthTime = 2f;
        public int cropScoreMultiplier = 1;
        public Vegetable cropToBePlanted;
        #endregion
        
        #region PLAYER WEAPON

        public float playerWeaponFireDelay = 1f;
        public float playerWeaponBulletSpeed = 1100f;
        public int playerWeaponDamage = 1;
        
        #endregion
        
        #region AUTO WEAPON

        public float autoGunFireDelay = 1f;
        public float autoGunBulletSpeed = 1100f;
        public int autoGunDamage = 1;
        public float autoGunTurnSpeed = 1f;
        
        #endregion
        
        #region ENEMIES

        public int enemyXpDropChance = 0;
        
        #endregion
        
        #region SHARED

        public float scannerRadius = 8f;
        public float xpMultiplier = 1f;
        
        #endregion
        
        #region INITIAL

        public float InitialScannerRadius { get; private set; }
        public float InitialXpMultiplier { get; private set; }
        
        #endregion

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            InitialScannerRadius = scannerRadius;
            InitialXpMultiplier = xpMultiplier;
        }
    }
}